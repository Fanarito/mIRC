using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Client
{

    public partial class Form1 : Form
    {
        List<string> last_messages = new List<string>();
        int up_count = 0;
        public bool Getmessages = false;
        public List<string> ListIDsRaw = new List<string>();
        public List<string> queued_memes = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Task.Factory.StartNew(Memes);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetMeme("http://s32.postimg.org/ol46s5s41/paypayx128.png");
        }

        public void InitializeTreeView()
        {
            foreach (var item in ListIDsRaw)
            {
                Log("ALLAH OGSNACKBAR " + item);
            }

            TreeGuiUpdate();
        }

        public void TreeGuiUpdate()
        {

            TREE_channels.Invoke((MethodInvoker)delegate
            {
                TREE_channels.BeginUpdate();
                TREE_channels.Nodes.Add("@root");
                TREE_channels.Nodes[0].Nodes.Add("Child 1");
                TREE_channels.Nodes[0].Nodes.Add("Child 2");
                TREE_channels.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
                TREE_channels.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
                TREE_channels.EndUpdate();
            });
        }
        public void Log(string message)
        {
            rtb_message_log.Invoke((MethodInvoker)delegate
            {
                //rtb_message_log.AppendText(message + "\r\n");
                rtb_message_log.Rtf = @"{\rtf1\ansi {\colortbl ;\red0\green128\blue0;\red0\green0\blue255;}" + rtb_message_log.Rtf + @"\line" + message + @"}";
                rtb_message_log.SelectionStart = rtb_message_log.TextLength;
                rtb_message_log.ScrollToCaret();
            });
        }

        private void rtb_send_message_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void rtb_send_message_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rtb_send_message.Text = rtb_send_message.Text.Trim();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Server.writer.Write("$disconnect");
            //Server.Disconnect();
            //Application.Exit();
            Environment.Exit(0);
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            Server.Connect(txt_username.Text, txt_ipaddress.Text, (int)nud_port.Value, this);
            tabControl1.SelectedIndex = 1;
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rtb_send_message.Text = rtb_send_message.Text.TrimEnd();
                Server.SendMessage(rtb_send_message.Text);
                last_messages.Insert(0, rtb_send_message.Text.TrimEnd());
                rtb_send_message.Clear();
                up_count = 0;
            }
            else if (e.KeyCode == Keys.Up)
            {
                rtb_send_message.Text = last_messages[up_count];
                if (last_messages.Count - 1 > up_count)
                    up_count++;
                rtb_message_log.SelectionStart = rtb_message_log.TextLength;
                rtb_message_log.ScrollToCaret();
            }
        }

        public void ShowID(string id)
        {
            LBL_channel.Invoke((MethodInvoker)delegate
            {
                LBL_channel.Text = id;
            });
        }

        public void Memes()
        {
            while (true)
            {
                if (queued_memes.ElementAtOrDefault(0) != null)
                {
                    SetMeme(queued_memes[0]);
                    queued_memes.RemoveAt(0);
                }

                Thread.Sleep(5000);
            }
        }

        public void SetMeme(string url)
        {
            pb_memes.Invoke((MethodInvoker)delegate
            {
                pb_memes.ImageLocation = url;
            });
        }
    }

    static class Server
    {
        public static Thread outputThread; // Thread for receiving data from server
        public static TcpClient connection; // client to establish connection
        public static NetworkStream stream; // network data stream
        public static BinaryWriter writer; // facilitates writing to the stream
        public static BinaryReader reader; // facilitates reading from the stream
        private static Form1 form;

        public static void Connect(string username, string ip_address, int port, Form1 _form)
        {
            // make connection to server and get the associated
            // network stream                                  
            connection = new TcpClient(ip_address, port);
            stream = connection.GetStream();
            writer = new BinaryWriter(stream);
            reader = new BinaryReader(stream);

            form = _form;

            form.InitializeTreeView();

            User.name = username;
            writer.Write(username);
            writer.Write("$get_channel_id");
            User.channel_id = reader.ReadString();
            form.ShowID(User.channel_id);

            // start a new thread for sending and receiving messages
            outputThread = new Thread(new ThreadStart(Run));
            outputThread.Start();
        }

        public static void Disconnect()
        {
            writer.Write("exiting");
            connection.Close();
            stream.Close();
            writer.Close();
            reader.Close();
        }

        public static void SendMessage(string message)
        {
            if (message.Trim() == "")
            {
                form.Log("eat a massive dick");
            }
            else
            {
                writer.Write(message);
            }
        }

        public static void ProcessMessage(string message)
        {

            if (message == "PrepareForUpdatedTreeInformation")
            {
                form.Getmessages = true;
            }

            if (!form.Getmessages)
            {
                if (message[0] == '$')
                {
                    ProcessCommand(message.Split(' '));
                }
                else
                {
                    //Console.WriteLine(message);
                    form.Log(message);
                }
            }
            else
            {
                form.ListIDsRaw.Clear();
                while (true)
                {
                    string strengur = reader.ReadString();

                    if (strengur == "Close")
                        break;

                    form.ListIDsRaw.Add(strengur);
                }
                form.Getmessages = false;
                form.InitializeTreeView();
            }

        }

        public static void ProcessCommand(string[] command)
        {
            switch (command[0])
            {
                case "$server_message":
                    form.Log("Server: " + command[1]);
                    break;
                case "$send_meme":
                    form.Log("meme recived");
                    form.queued_memes.Add(command[1]);
                    break;
                case "$channel_id":
                    form.ShowID(command[1]);
                    break;
                default:
                    break;
            }
        }

        static void Run()
        {
            try
            {
                // Receive messages sent to client from server
                while (true)
                {
                    ProcessMessage(reader.ReadString());
                }
            }
            catch (IOException ex)
            {
                form.Log("Server is down");
                form.Log(ex.ToString());
                Thread.Sleep(1000);
            }
        }
    }

    static class User
    {
        public static string name;
        public static string channel_id;
    }
}
