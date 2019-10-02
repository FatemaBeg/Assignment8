using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Order
    {
        public int CustomerId { set; get; }
        public int ItemId { set; get; }
        public int Quantity { set; get; }
        public int TotalPrice { set; get; }
    }
}
