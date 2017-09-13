using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prototype_Auction
{
    class Program
    {
        TcpListener listener;
        BiddingSystem biddingSystem;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();       
        }

        void Run()
        {
            biddingSystem = new BiddingSystem(); 
            Console.WriteLine("Starting server...");

            Thread acceptClientThread;

            int port = 11000;
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            ThreadStart acceptClientDelegate = new ThreadStart(AcceptClient);
            acceptClientThread = new Thread(acceptClientDelegate);
            acceptClientThread.Start();

            Console.ReadKey();
        }

        void AcceptClient()
        {
            while(true)
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                biddingSystem.AddStream(stream);
            }
        }
    }
}
