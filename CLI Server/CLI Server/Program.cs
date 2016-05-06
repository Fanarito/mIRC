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
        static int port = 3679;
        static int user_port = 3680;
        static Channel root;

        static void Main(string[] args)
        {
            // Creating root channel
            root = new Channel("root");
            // Start a UserGetter
            Task.Factory.StartNew(UserGetter);
            Console.ReadLine();
        }

        static void UserGetter()
        {
            Console.WriteLine("Starting TCP listener...");
            TcpListener listener = new TcpListener(IPAddress.Parse(ip), port);
            TcpListener user_listener = new TcpListener(IPAddress.Parse(ip), user_port);
            listener.Start();
            user_listener.Start();
            Console.WriteLine("TCP listener started on " + ip + ":" + port);

            while (true)
            {
                var user = new User(listener.AcceptSocket(), user_listener.AcceptSocket(), root, root);
                Task.Factory.StartNew(user.Server_Run);
                Task.Factory.StartNew(user.User_Run);
                Console.WriteLine("Connection accepted");
            }
        }
    }
}
