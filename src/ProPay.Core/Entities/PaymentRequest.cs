using ProPay.Core.Interfaces;
using ProPay.SharedKernel;
using System;

namespace ProPay.Core.Entities
{
    public class PaymentRequest : BasePaymentEntity
    {
        public string CreditCardNumber { get; set; } = string.Empty;
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public float Amount { get;  set; }


        public override string ToString()
        {
           // string status = IsDone ? "Done!" : "Not done.";
            return""; // $"{Id}: Status: {status} - {Title} - {Description}";
        }
    }
}
