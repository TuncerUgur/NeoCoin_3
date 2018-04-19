using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_SqlDepenciy.Models
{
    public class Sell
    {
        public int Id { get; set; }
        public double quantity { get; set; }
        public double Total { get; set; }
        public double Price { get; set; }
 
    }
}