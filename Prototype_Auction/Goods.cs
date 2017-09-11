using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Auction
{
    public class Goods
    {
        public string Name { get; set; }
        public double StartingPrice { get; set; }
        public double  CurrentPrice { get; set; }

        private Bidder bidder;

        public void SetBidder(Bidder bidder)
        {
            this.bidder = bidder;
        }

        public Bidder GetBidder() => bidder;
        
    }
}
