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
        static void Main(string[] args)
        {
            BiddingSystem biddingSystem = new BiddingSystem();
            Thread acceptClientThread;
            Console.WriteLine("Starting server...");

            int port = 11000;
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            ThreadStart acceptClientDelegate = new ThreadStart(AcceptClient(listener, biddingSystem: biddingSystem));
            acceptClientThread = new Thread(acceptClientDelegate);
            acceptClientThread.Start();

            // this should be reimplemented using threads
            


            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);

            //while(true)
            //{
            //    string inputLine = "";

            //    while (inputLine != null)
            //    {
            //        inputLine = reader.ReadLine();

            //        //writer.WriteLine(AnswerGenerator(inputLine));
            //        Console.WriteLine("Received: " + inputLine);
            //    }
            //    Console.WriteLine("Server saw disconnect from client.");
            //}

            Console.ReadKey();
        }

        static void AcceptClient(TcpListener listener, BiddingSystem biddingSystem)
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
