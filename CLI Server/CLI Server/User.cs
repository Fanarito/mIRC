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
        internal Socket user_connection;
        internal Socket server_connection;
        private NetworkStream user_stream;
        private NetworkStream server_stream;

        internal BinaryWriter user_writer;
        internal BinaryWriter server_writer;
        private BinaryReader user_reader;
        private BinaryReader server_reader;

        private string name;
        public Channel channel;
        public Channel root;

        public User(Socket server_socket, Socket user_socket, Channel _channel, Channel _root)
        {
            user_connection = user_socket;
            server_connection = server_socket;
            channel = _channel;
            channel.AddUser(this);
            root = _root;

            // Create NetworkStream object for Socket
            user_stream = new NetworkStream(user_connection);
            server_stream = new NetworkStream(server_connection);

            // Create Streams for reading/writing bytes
            user_writer = new BinaryWriter(user_stream);
            server_writer = new BinaryWriter(server_stream);
            user_reader = new BinaryReader(user_stream);
            server_reader = new BinaryReader(server_stream);
        }

        public void SetName(string new_name)
        {
            name = new_name;
        }

        public void SetChannel(Channel _channel)
        {
            channel.UserLeave(this);
            channel = _channel;
            channel.AddUser(this);
            /*Channel change = null;
            foreach (var chan in channel.channels)
            {
                if (chan.name == channel_name)
                {
                    change = chan;
                    channel = chan;
                }
            }*/
        }

        public void SetChannel(string channel_name)
        {
            if (channel_name[0] == '@')
            {
                Channel buff = channel;

                while (buff.parent != null)
                {
                    buff = buff.parent;
                }
                SetChannel(buff);
            }
            else
            {
                foreach (var _channel in channel.channels)
                {
                    //Console.WriteLine(_channel.name);
                    if (_channel.name == channel_name)
                    {
                        //SetChannel(_channel);
                        channel.UserLeave(this);
                        channel = _channel;
                        channel.AddUser(this);
                        return;
                    }
                }
            }
        }

        public void SendMessage(string message)
        {
           user_writer.Write(message);
        }

        private void ProcessUserMessage(string message)
        {
            try
            {
                if (message[0] == '$')
                {
                    ProcessCommand(message.Substring(1));
                }
                else
                {
                    channel.Broadcast(name + " " + channel.id + " > " + message);
                    Console.WriteLine(name + " " + channel.id + " > " + message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Empty message.");
                server_writer.Write("Empty message.");
            }
        }

        private void ProcessServerMessage(string message)
        {
            try
            {
                if (message[0] == '$')
                {
                    ProcessCommand(message.Substring(1));
                }
                else
                {
                    channel.Broadcast(name + " " + channel.id + " > " + message);
                    Console.WriteLine(name + " " + channel.id + " > " + message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Empty message.");
                server_writer.Write("Empty message.");
            }
        }

        private void ProcessCommand(string _command)
        {
            //channel.Broadcast(command);
            string[] command = _command.Split(' ');
            switch (command[0])
            {
                case "get_channel_id":
                    server_writer.Write(channel.id);
                    break;
                case "get_channels":
                    // Writes out all child channels to client
                    channel.GetChannelList(server_writer);
                    break;
                case "create":
                    channel.addChannel(command[1]);
                    SetChannel(command[1]);
                    //channel.JoinChildChannel(command[1], this);
                    server_writer.Write(channel.id);
                    server_writer.Write("created and joined " + command[1]);
                    Console.WriteLine(channel.id);
                    break;
                case "join":
                    SetChannel(command[1]);
                    server_writer.Write(channel.id);
                    server_writer.Write("joined " + command[1]);
                    break;
                default:
                    server_writer.Write("Command not recognized");
                    break;
            }
        }

        public void User_Run()
        {
            using (user_connection)
            {
                name = user_reader.ReadString();
                ProcessUserMessage(user_reader.ReadString());

                while (true)
                {
                    try
                    {
                        ProcessUserMessage(user_reader.ReadString());
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(name + " disconnected");
                        break;
                        //Disconnect();
                    }
                }
            }
        }

        public void Server_Run() 
        {
            using (server_connection)
            {
                name = server_reader.ReadString();
                ProcessServerMessage(server_reader.ReadString());

                Console.WriteLine(name + " connected");
                server_writer.Write("$server_message connection confirmed");

                while (true)
                {
                    try
                    {
                        ProcessServerMessage(server_reader.ReadString());
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(name + " disconnected");
                        break;
                        //Disconnect();
                    }
                }
            }
        }

        private void Disconnect()
        {
            user_connection.Close();
            user_stream.Close();
            user_writer.Close();
            user_reader.Close();
        }
    }
}
