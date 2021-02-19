using Microsoft.Extensions.Logging;
using ProPay.Core.Interfaces;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProPay.Infrastructure
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {

        public ExpensivePaymentGateway()
        {
        }

        public async Task<bool> AcceptPayment(float Amount, string CreditCardNumber, DateTime ExpirationDate, string SecurityCode)
        {

            //generate random true or false
            var random = new Random();
            return random.Next(10) < 4;
        }
    }
}
