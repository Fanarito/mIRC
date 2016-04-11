using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CLI_Server
{
    class User
    {
        // Connection stuffs
        internal Socket connection;
        private NetworkStream socketStream;
        internal BinaryWriter writer;
        private BinaryReader reader;

        private string name;
        private Channel channel;

        public User(Socket socket, Channel _channel)
        {
            connection = socket;
            channel = _channel;
            channel.AddUser(this);

            // Create NetworkStream object for Socket
            socketStream = new NetworkStream(connection);

            // Create Streams for reading/writing bytes
            writer = new BinaryWriter(socketStream);
            reader = new BinaryReader(socketStream);
        }

        public void SetName(string new_name)
        {
            name = new_name;
        }

        public void SetChannel(string channel_name)
        {
            Channel change = null;
            foreach (var chan in channel.channels)
            {
                if (chan.name == channel_name)
                {
                    change = chan;
                }
            }
            if (change != null)
            {
                channel.UserLeave(this);
                channel = change;
            }
        }

        public void SendMessage(string message)
        {
            writer.Write(message);
        }

        private void ProcessMessage(string message)
        {
            if (message.Trim() == "\r\n")
            {
                SendMessage("fuckoff");
            }
            else
            {
                channel.Broadcast(message);
                Console.WriteLine(message);
            }
            
        }

        public void Run()
        {
            using (connection)
            {
                name = reader.ReadString();
                Console.WriteLine(name + " connected");
                writer.Write("$server_message connection confirmed");
                while (true)
                {
                    ProcessMessage(reader.ReadString());
                }
            }
        }

        private void Disconnect()
        {
            connection.Close();
            socketStream.Close();
            writer.Close();
            reader.Close();
        }
    }
}
