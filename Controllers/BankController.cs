using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {


        
        CardAccount card1 = new CardAccount("6759291632878588", "12/22", 127, "MASTERCARD","Tom Hardy",10000);
        CardAccount card2 = new CardAccount("6226323207911141", "01/23", 333, "MASTERCARD","Micheal Sin",20000);
        CardAccount card3 = new CardAccount("6762476347202597", "05/22", 217, "MASTERCARD", "Billy Black",5000);
        CardAccount card4 = new CardAccount("4547739567657049", "04/22", 444, "VISA", "Homer Simpsons",1000);
        CardAccount card5 = new CardAccount("2377054708263528", "12/22", 101, "VISA", "Sarah Chu",100000);
        CardAccount card6 = new CardAccount("4017618626082491", "06/23", 162, "VISA", "Ansley Singleton",500);
        CardAccount card7 = new CardAccount("6229061805750548", "03/19", 425, "DISCOVER", "Danica Greene",200);
        Dictionary<string, CardAccount> accountsDictionary;
       


        // POST: api/Bank
        [HttpPost]
        public ActionResult<BankResponse> PostMakePayment(PayRequest payReq)
        {
            Console.WriteLine("Received request");
            accountsDictionary = new Dictionary<string, CardAccount>()
            {
                {"6759291632878588",card1 },{"6226323207911141",card2 },{"6762476347202597",card3 },{"4547739567657049",card4 },{"2377054708263528",card5 },{"4017618626082491",card6 },{"6229061805750548",card7 },
            };
            CardAccount card;
            BankResponse bankResponse = new BankResponse();
            bankResponse.Identifier = Guid.NewGuid().ToString();
            if (!accountsDictionary.TryGetValue(payReq.Cardnumber,out card))
            {
                bankResponse.Status = 2000;
                return BadRequest(bankResponse);
            }

            if (!payReq.ExpiryDate.Equals(card.ExpiryDate))
            {
                bankResponse.Status = 2003;
                return BadRequest(bankResponse);
            }
           
           
            string date = "01/" + card.ExpiryDate;
            DateTime dt1 = DateTime.Parse(date);
            DateTime dt2 = DateTime.Now;
           

            if ((dt1.Year - dt2.Year) < 0 || (dt1.Year - dt2.Year) > 3 && dt1.Month < dt2.Month)
            {
                bankResponse.Status = 2004;
                return BadRequest(bankResponse);
            }

            

            if (card.Cvv != payReq.Cvv)
            {
                bankResponse.Status = 2001;
                return BadRequest(bankResponse);
            }

            if (payReq.Amount > card.Balance)
            {
                bankResponse.Status = 2002;
                return BadRequest(bankResponse);
            }

            bankResponse.Status = 1000;
            return Ok(bankResponse);
        }

       
       

      
    }
}
