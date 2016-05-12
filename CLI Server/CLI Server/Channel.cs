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
    class Channel
    {
        private static Random _random = new Random();
        public List<User> users = new List<User>();
        public string name;
        private int user_count;
        public List<Channel> channels = new List<Channel>();
        public string id;
        public Channel parent;
        private ConsoleColor color;
        private string motd;

        public Channel(string _name, Channel _parent = null, ConsoleColor _color = ConsoleColor.Black)
        {
            //name = "#" + _name;
            name = _name;
            parent = _parent;
            user_count = 0;

            /*if (_color == ConsoleColor.Black && parent != null)
            {
                do
                {
                    color = GetRandomConsoleColor();
                } while (parent.color == color);
            }*/

            if (parent != null)
                id = parent.id + name;
            else
            {
                id = "@root";
                name = "@root";
                color = ConsoleColor.DarkRed;
            }
            Console.WriteLine("Created " + id);
        }

        private static ConsoleColor GetRandomConsoleColor()
        {
            return ConsoleColor.Red;
        }

        private void UpdateClientTrees()
        {
            BroadcastToServer("PrepareForUpdatedTreeInformation");
            foreach (var item in channels)
            {
                BroadcastToServer(item.id);
            }
            BroadcastToServer("Close");
        }

        public void addChannel(string _name)
        {
            channels.Add(new Channel(_name, this));
            UpdateClientTrees();
        }

        public void removeChannel(string id)
        {
            foreach (var item in channels)
            {
                if (item.id == id)
                {
                    channels.Remove(item);
                    break;
                }
            }
            UpdateClientTrees();
        }
        public void GetChannelList(BinaryWriter writer)
        {
            string channel_string = "";
            foreach (var channel in channels)
            {
                //Console.ForegroundColor = channel.color;
                Console.WriteLine(channel.id);
                writer.Write(channel.id);
                channel.GetChannelList(writer);
            }
        }
        public void GetChannelListRaw(BinaryWriter writer)
        {
            List<string> ChannelIDs = new List<string> { };
            foreach (var item in channels)
            {
                writer.Write(item.id);
            }
        }
        public void UserLeave(User userino)
        {
            users.Remove(userino);
        }

        public void AddUser(User userino)
        {
            users.Add(userino);
        }

        public void JoinChildChannel(string channel_name, User userino)
        {
            foreach (var channel in channels)
            {
                Console.WriteLine(channel.id);
                if (channel.name == channel_name)
                {
                    UserLeave(userino);
                    channel.AddUser(userino);
                    //userino.SetChannel(channel);
                    userino.channel = channel;
                    Console.WriteLine(userino.channel.id);
                    break;
                }
            }
        }

        public Channel FindRoot()
        {
            Channel buff = this;

            while (buff.parent != null)
            {
                buff = buff.parent;
            }

            return buff;
        }

        public void BroadcastToServer(string message, Channel buff = null)
        {
            if (buff == null)
            {
                buff = FindRoot();
                buff.BroadcastToChannel(message);
            }

            foreach (var channel in buff.channels)
            {
                channel.BroadcastToChannel(message);
                BroadcastToServer(message, channel);
            }
        }

        public void BroadcastToServer(List<string> message, Channel buff = null)
        {
            if (buff == null)
            {
                buff = FindRoot();
                buff.BroadcastToChannel(message);
            }

            foreach (var channel in buff.channels)
            {
                channel.BroadcastToChannel(message);
                BroadcastToServer(message, channel);
            }
        }

        public List<string> FindAllChannelsOnServer(List<string> id_list = null, Channel buff = null)
        {
            if (id_list == null)
            {
                id_list = new List<string>();
            }
            if (buff == null)
            {
                buff = FindRoot();
                Console.WriteLine(buff.id);
                id_list.Add(buff.id);
            }

            foreach (var channel in buff.channels)
            {
                Console.WriteLine(channel.id);
                id_list.Add(channel.id);
                id_list.Concat(FindAllChannelsOnServer(id_list, channel));
            }
            return id_list;
        }

        public void BroadcastToChannel(string message, string sender = "")
        {
            foreach (var user in users)
            {
                bool blocked = false;
                if (sender != "")
                {
                    foreach (var blocked_user in user.blocked)
                    {
                        if (blocked_user.Name == sender)
                        {
                            blocked = true;
                            break;
                        }
                    }
                }
                if (!blocked)
                    user.SendMessage(message);
            }
        }

        public void BroadcastToChannel(List<string> message, string sender = "")
        {
            foreach (var user in users)
            {
                bool blocked = false;
                if (sender != "")
                {
                    foreach (var blocked_user in user.blocked)
                    {
                        if (blocked_user.Name == sender)
                        {
                            blocked = true;
                            break;
                        }
                    }
                }
                if (!blocked)
                {
                    foreach (var mes in message)
                    {
                        user.SendMessage(mes);
                    }
                }
            }
        }
    }
}
