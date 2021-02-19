using ProPay.Core.Entities;
using ProPay.SharedKernel.Interfaces;
using System.Linq;

namespace ProPay.Core
{
    public static class DatabasePopulator
    {
        public static int PopulateDatabase(IPaymentRepository paymentRepository)
        {
            if (paymentRepository.ListAsync<PaymentDetails>().Result.Count() >= 1) return 0;

            paymentRepository.AddAsync(new PaymentDetails
            {
                CreditCardNumber = "Get Sample Working",
                CardHolder = "sample",
                Amount = 50
            }).Wait();

            return paymentRepository.ListAsync<PaymentDetails>().Result.Count;
        }
    }
}
