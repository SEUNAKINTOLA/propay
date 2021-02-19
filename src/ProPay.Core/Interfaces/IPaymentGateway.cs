using System;
using System.Threading.Tasks;

namespace ProPay.Core.Interfaces
{
    public interface IPaymentGateway
    {
        Task<bool> AcceptPayment(float Amount, string CreditCardNumber, DateTime ExpirationDate, string SecurityCode);
    }
}
