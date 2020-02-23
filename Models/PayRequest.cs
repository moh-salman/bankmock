using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Models
{
    public class PayRequest
    {
        public string CardHolderName { get; set; }
        public string Cardnumber { get; set; }

        public string ExpiryDate { get; set; }

        public int Cvv { get; set; }

        public string CardType { get; set; }

        public string Currency { get; set; }

        public double Amount { get; set; }
    }
}
