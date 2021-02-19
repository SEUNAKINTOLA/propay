using ProPay.Core.Entities;
using System;

namespace ProPay.UnitTests
{
    // Learn more about test builders:
    // https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    public class PaymentDetailsBuilder
    {
        private PaymentDetails _payment = new PaymentDetails();

        public PaymentDetailsBuilder Id(Guid id)
        {
            _payment.Id = id;
            return this;
        }

        public PaymentDetailsBuilder CreditCardNumber(string creditcardnumber)
        {
            _payment.CreditCardNumber = creditcardnumber;
            return this;
        }

        public PaymentDetailsBuilder CardHolder(string cardholder)
        {
            _payment.CardHolder = cardholder;
            return this;
        }
        public PaymentDetailsBuilder Amount(float amount)
        {
            _payment.Amount = amount;
            return this;
        }
        
        public PaymentDetailsBuilder WithDefaultValues()
        {
            _payment = new PaymentDetails() { Id = new Guid(), CreditCardNumber = "Test Number", CardHolder = "Test CardHolder" };

            return this;
        }

        public PaymentDetails Build() => _payment;
    }
}
