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
        public Channel channel;
        public Channel root;

        Dictionary<string, string> help = new Dictionary<string, string>()
        {
            {"get_channel_id", "Sends the user the id of his current channel \r\n<usage> $get_channel_id </usage>"},
            {"get_channels", "Sends the user all ids of every channel on the server \r\n<usage> $get_channels </usage>"},
            {"create", "Creates a new channel with a specified name in the current channel \r\n<usage> $create #name_of_channel </usage>"},
            {"join", "Joins a specified channel by either name or id, if the channel exists \r\n<usage> $join #name_of_channel </usage>"},
            {"send_meme", "This is the bread and butter of this application, sends a meme with a specified url \r\n<usage> $send_meme http://example.com/pic.jpg </usage>"},
            {"help", "Displays all available commands, or if you include a command it displays info about it\r\n<usage> $help send_meme </usage>"}
        };

        public User(Socket socket, Channel _channel, Channel _root)
        {
            connection = socket;
            channel = _channel;
            channel.AddUser(this);
            root = _root;

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
            writer.Write(message);
        }

        private void ProcessMessage(string message)
        {
            try
            {
                if (message[0] == '$')
                {
                    ProcessCommand(message.Substring(1));
                }
                else
                {
                    Console.WriteLine("reynir ad senda");
                    channel.BroadcastToChannel(name + " " + channel.id + " > " + message);
                    Console.WriteLine(name + " " + channel.id + " > " + message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("message failed");
                Console.WriteLine("Empty message.");
                writer.Write("Empty message.");
            }
        }

        private void ProcessCommand(string _command)
        {
            //channel.Broadcast(command);
            string[] command = _command.Split(' ');
            switch (command[0])
            {
                case "get_channel_id":
                    writer.Write(channel.id);
                    break;
                case "get_channels":
                    // Writes out all child channels to client
                    channel.GetChannelList(writer);
                    break;
                case "create":
                    channel.addChannel(command[1]);
                    SetChannel(command[1]);
                    //channel.JoinChildChannel(command[1], this);
                    writer.Write("created and joined " + command[1]);
                    writer.Write("$channel_id " + channel.id);
                    Console.WriteLine(channel.id);
                    break;
                case "join":
                    SetChannel(command[1]);
                    writer.Write("joined " + command[1]);
                    writer.Write("$channel_id " + channel.id);
                    break;
                case "send_meme":
                    channel.BroadcastToChannel("$send_meme " + command[1]);
                    Console.WriteLine("sendi meme " + command[1]);
                    break;
                case "ping":
                    writer.Write("Pong!");
                    break;
                case "wag":
                    channel.BroadcastToChannel(name + " has SWAG!");
                    break;
                case "help":{
                    if (command.ElementAtOrDefault(1) != null)
                    {
                        writer.Write(help[command[1]]);
                    }
                    else
                    {
                        foreach (KeyValuePair<string, string> item in help)
                        {
                            this.writer.Write(String.Format("{0}: {1}\r\n", item.Key, item.Value));
                        }
                    }}
                    break;
                default:
                    writer.Write("Command not recognized");
                    break;
            }
        }

        public void Run()
        {
            using (connection)
            {
                name = reader.ReadString();
                ProcessMessage(reader.ReadString());

                Console.WriteLine(name + " connected");
                writer.Write("$server_message connection confirmed");
                while (true)
                {
                    try
                    {
                        ProcessMessage(reader.ReadString());
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(name + " disconnected");
                        Disconnect();
                        break;
                    }
                }
            }
        }

        private void Disconnect()
        {
            connection.Close();
            socketStream.Close();
            writer.Close();
            reader.Close();
            channel.UserLeave(this);
        }
    }
}