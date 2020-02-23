using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Models
{
    public class CardAccount
    {
        public string CardHolderName { get; set; }   
        public string Cardnumber { get; set; }

        public string ExpiryDate { get; set; }

        public int Cvv { get; set; }

        public string CardType { get; set; }

        public double Balance { get; set; }

        public CardAccount(string cardNumber,string expiryDate,int cvv,string cardType,string cardHolderName,double balance)
        {
            CardHolderName = cardHolderName;
            Cardnumber = cardNumber;
            ExpiryDate = expiryDate;
            Cvv = cvv;
            CardType = cardType;
            Balance = balance;
        }
    }
}
