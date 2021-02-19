using ProPay.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProPay.Web.ApiModels
{
    // Note: doesn't expose events or behavior
    public class PaymentRequestDTO
    {
        [Required]
        public string CreditCardNumber { get; set; }


        [Required]
        public string CardHolder { get; set; }


        [Required]
        public DateTime ExpirationDate { get; set; }

        [StringLength(3)]
        public string SecurityCode { get; set; }


        [Required]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public float Amount { get; set; }


        public static PaymentDetails PaymentDetailsFromRequest(PaymentRequestDTO item)
        {
            return new PaymentDetails()
            {
                CreditCardNumber = item.CreditCardNumber,
                Amount = item.Amount,
                CardHolder = item.CardHolder
            };
        }
        public static PaymentRequest GetPaymentRequestEntity(PaymentRequestDTO item)
        {
            return new PaymentRequest()
            {
                CreditCardNumber = item.CreditCardNumber,
                Amount = item.Amount,
                CardHolder = item.CardHolder,
                ExpirationDate = item.ExpirationDate,
                SecurityCode = item.SecurityCode
            };
        }
    }
}
