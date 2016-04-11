using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CLI_Server
{
    class Program
    {
        static string ip = "127.0.0.1";
        static int port = 50000;
        static Channel root;

        static void Main(string[] args)
        {
            /*Channel root = new Channel("root");
            Console.WriteLine(root.id);
            Console.WriteLine(root.name);
            Console.ReadLine();

            root.addChannel("thing");
            root.channels[0].addChannel("wutwut");
            root.channels[0].channels[0].addChannel("wutwut");
            root.channels[0].channels[0].addChannel("dickwad");
            root.channels[0].channels[0].addChannel("wutwwut");
            root.channels[0].channels[0].addChannel("dicakwad");
            root.channels[0].channels[0].channels[0].addChannel("wut");
            root.channels[0].channels[0].channels[0].addChannel("wuta");
            root.channels[0].channels[0].channels[0].addChannel("wutaa");
            root.channels[0].channels[0].channels[3].addChannel("nei");
            root.addChannel("neinei");
            root.channels[0].addChannel("jaja");
            root.channels[0].addChannel("kkk");
            root.addChannel("wut");
            root.addChannel("thong");
            root.getChannelList();
            //Console.WriteLine(root.channels[0].id);
            Console.ReadLine();*/

            // Creating root channel
            root = new Channel("root");
            Task.Factory.StartNew(UserGetter);
            Console.ReadLine();
        }

        static void UserGetter()
        {
            Console.WriteLine("Starting TCP listener...");
            TcpListener listener = new TcpListener(IPAddress.Parse(ip), port);
            listener.Start();
            Console.WriteLine("TCP listener started on " + ip + ":" + port);

            while (true)
            {
                var user = new User(listener.AcceptSocket(), root);
                Task.Factory.StartNew(user.Run);
                Console.WriteLine("Connection accepted");
            }
        }
    }
}
