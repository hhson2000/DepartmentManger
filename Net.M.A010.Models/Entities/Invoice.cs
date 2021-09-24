using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.M.A010.Models.Entities
{
    class Invoice : Payable
    {
        public string partNumber { get; set; }
        public string partDescription { get; set; }

        public int quantity { get; set; }

        public double pricePerItem { get; set; }

        public double getPaymentAmount()
        {
            return quantity*pricePerItem;
        }
    }
}
