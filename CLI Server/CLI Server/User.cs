﻿using System;
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
                    Console.WriteLine(channel.id);
                    break;
                case "join":
                    SetChannel(command[1]);
                    writer.Write("joined " + command[1]);
                    break;
                case "send_meme":
                    channel.BroadcastToChannel("$send_meme " + command[1]);
                    Console.WriteLine("sendi meme " + command[1]);
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