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

        public Form1()
        {
            InitializeComponent();
            InitializeTreeView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //shit fyrir Treeview
        private void InitializeTreeView()
        {
            TREE_channels.BeginUpdate();
            TREE_channels.Nodes.Add("@root");
            TREE_channels.Nodes[0].Nodes.Add("Child 1");
            TREE_channels.Nodes[0].Nodes.Add("Child 2");
            TREE_channels.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            TREE_channels.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            TREE_channels.EndUpdate();
        }

        public void Log(string message)
        {
            rtb_message_log.Invoke((MethodInvoker)delegate
            {
                rtb_message_log.AppendText(message + "\r\n");
                rtb_message_log.SelectionStart = rtb_message_log.TextLength;
                rtb_message_log.ScrollToCaret();
            });
        }

        public void ShowID(string id)
        {
            LBL_channel.Invoke((MethodInvoker)delegate
            {
                LBL_channel.Text = id;
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
            Server.Disconnect();
            Application.Exit();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            Server.Connect(txt_username.Text, txt_ipaddress.Text, (int)nud_user_port.Value, (int)nud_server_port.Value, this);
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
                if (last_messages.Count-1 > up_count)
                    up_count++;
                rtb_message_log.SelectionStart = rtb_message_log.TextLength;
                rtb_message_log.ScrollToCaret();
            }
        }
    }

    static class Server
    {
        public static Thread user_thread; // Thread for receiving data from server
        public static Thread server_thread; // Thread for receiving data from server
        public static TcpClient user_connection; // client to establish connection
        public static TcpClient server_connection; // client to establish connection
        public static NetworkStream user_stream; // network data stream
        public static NetworkStream server_stream; // network data stream

        public static BinaryWriter user_writer; // facilitates writing to the stream
        public static BinaryReader user_reader; // facilitates reading from the stream
        public static BinaryWriter server_writer;
        public static BinaryReader server_reader;

        private static Form1 form;

        public static void Connect(string username, string ip_address, int user_port, int server_port, Form1 _form)
        {
            // make connection to server and get the associated
            // network stream                                  
            user_connection = new TcpClient(ip_address, user_port);
            server_connection = new TcpClient(ip_address, server_port);
            user_stream = user_connection.GetStream();
            server_stream = user_connection.GetStream();
            user_writer = new BinaryWriter(user_stream);
            user_reader = new BinaryReader(user_stream);
            server_writer = new BinaryWriter(server_stream);
            server_reader = new BinaryReader(server_stream);

            form = _form;

            User.name = username;
            server_writer.Write(username);
            server_writer.Write("$get_channel_id");
            User.channel_id = server_reader.ReadString();
            form.ShowID(User.channel_id);

            // start a new thread for sending and receiving messages
            user_thread = new Thread(new ThreadStart(UserRun));
            user_thread.Start();
            server_thread = new Thread(new ThreadStart(ServerRun));
            server_thread.Start();
        }

        public static void Disconnect()
        {
            //writer.Write("exiting");
            /*connection.Close();
            stream.Close();
            writer.Close();
            reader.Close();*/
        }

        public static void SendMessage(string message)
        {
            if (message.Trim() == "")
            {
                form.Log("get yo memes straight");
            }
            /*else if (message[0] == '$')
            {
                string[] command = message.Split(' ');
                switch (command[0])
                {
                    case "join":
                        writer.Write(message);
                        form.ShowID(reader.ReadString());
                        break;
                    case "create":
                        writer.Write(message);
                        form.ShowID(reader.ReadString());
                        break;
                    default:
                        break;
                }
                writer.Write(message);
            }*/
            else
            {
                user_writer.Write(message);
            }
        }

        public static void ProcessMessage(string message)
        {
            if (message[0] == '$')
            {
                form.Log(message);
            }
            else
            {
                //Console.WriteLine(message);
                form.Log(message);
            }
        }

        static void UserRun()
        {
            try
            {
                // Receive messages sent to client from server
                while (true)
                {
                    ProcessMessage(user_reader.ReadString());
                }
            }
            catch (IOException ex)
            {
                form.Log("Server is down");
                form.Log(ex.ToString());
                Thread.Sleep(1000);
            }
        }

        static void ServerRun()
        {
            try
            {
                // Receive messages sent to client from server
                while (true)
                {
                    ProcessMessage(server_reader.ReadString());
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
