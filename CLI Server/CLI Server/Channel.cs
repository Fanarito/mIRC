using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Server
{
    class Channel
    {
        private static Random _random = new Random();
        // cancer
        private static ConsoleColor[] legalColors = new ConsoleColor[12] { ConsoleColor.DarkGreen, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.DarkGray, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow };
        private List<User> users = new List<User>();
        public string name;
        private int user_count;
        public List<Channel> channels = new List<Channel>();
        public string id;
        private Channel parent;
        private ConsoleColor color;

        public Channel(string _name, Channel _parent = null, ConsoleColor _color = ConsoleColor.Black)
        {
            name = "#" + _name;
            parent = _parent;
            user_count = 0;

            if (_color == ConsoleColor.Black && parent != null)
            {
                do
                {
                    color = GetRandomConsoleColor();
                } while (parent.color == color);
            }

            if (parent != null)
                id = parent.id + name;
            else
            {
                id = "#root";
                color = ConsoleColor.DarkRed;
            }
        }

        private static ConsoleColor GetRandomConsoleColor()
        {
            return legalColors[_random.Next(12)];
        }

        public void addChannel(string _name)
        {
            channels.Add(new Channel(_name, this));
        }

        public void getChannelList()
        {
            foreach (var channel in channels)
            {
                Console.ForegroundColor = channel.color;
                Console.WriteLine(channel.id);
                channel.getChannelList();
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void UserLeave(User userino)
        {
            foreach (var user in users)
            {
                if (user == userino)
                {
                    users.Remove(user);
                    break;
                }
            }
        }

        public void AddUser(User userino)
        {
            users.Add(userino);
        }

        public void Broadcast(string message)
        {
            foreach (var user in users)
            {
                user.SendMessage(message);
            }
        }
    }
}
