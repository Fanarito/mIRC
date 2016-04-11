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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Server.Connect("jolli", this);
        }

        public void Log(string message)
        {
            rtb_message_log.Invoke((MethodInvoker)delegate
            {
                rtb_message_log.AppendText(message + "\r\n");
            });
        }

        private void rtb_send_message_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rtb_send_message.Text = rtb_send_message.Text.TrimEnd();
                Server.SendMessage(rtb_send_message.Text);
                rtb_send_message.Clear();
            }
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

        public static void Connect(string username, Form1 _form)
        {
            // make connection to server and get the associated
            // network stream                                  
            connection = new TcpClient("127.0.0.1", 50000);
            stream = connection.GetStream();
            writer = new BinaryWriter(stream);
            reader = new BinaryReader(stream);

            form = _form;

            User.name = username;
            writer.Write("");

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
            writer.Write(User.name + "> " + message);
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
    }
}
