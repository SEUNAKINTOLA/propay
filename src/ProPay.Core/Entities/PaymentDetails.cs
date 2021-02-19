using ProPay.Core.Interfaces;
using ProPay.SharedKernel;

namespace ProPay.Core.Entities
{
    public class PaymentDetails : BasePaymentEntity
    {
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public string PaymentState { get; private set; }
        public float Amount        { get; set; }

        public void MarkInitiated()
        {
            PaymentState = "pending";
        }
        public void MarkFailed()
        {
            PaymentState = "failed";
        }
        public void MarkDone()
        {
            PaymentState = "processed";
        }
        public override string ToString()
        {
            return  $"{Id}: CreditCardNumber: {CreditCardNumber} - {CardHolder} - {Amount}";
        }
    }
}
