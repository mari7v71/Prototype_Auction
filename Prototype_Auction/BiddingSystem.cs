using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Prototype_Auction
{
    public class BiddingSystem
    {
        //private List<NetworkStream> streams = new List<NetworkStream>();
        private List<Thread> threads = new List<Thread>();
        bool firstClientConnected = false;
        Goods goodsBeingSold;

        Goods testGoods = new Goods { Name = "Old PC", StartingPrice = 599.00, CurrentPrice = 599.00 };      
        
        public BiddingSystem()
        {
            // for testing purposes
            goodsBeingSold = testGoods;
        }

        private void InitializeBidding(Goods goods)
        {
            Console.WriteLine("Bidding has started...");
            Console.WriteLine("Item: {0}, Starting Price: {1}", goods.Name, goods.StartingPrice.ToString("F"));
        }

        private void StartBidding()
        {
            while (true)
            {
                // not implemented
            }
        }

        private void GreetNewClient(NetworkStream clientToGreet)
        {
            StreamWriter writer = new StreamWriter(clientToGreet, Encoding.ASCII) { AutoFlush = true };
            writer.WriteLine("Item: {0}, Starting Price: {1}, Current Price: {2}", goodsBeingSold.Name, goodsBeingSold.StartingPrice.ToString("F"), goodsBeingSold.CurrentPrice.ToString("F"));
        }

        public void AddStream(NetworkStream stream)
        {
            streams.Add(stream);
            Console.WriteLine("\nA new client connected...");

            if (firstClientConnected == false)
            {
                InitializeBidding(testGoods);
            }

            GreetNewClient(stream);
        }
    }
}

