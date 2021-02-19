using Ardalis.GuardClauses;
using ProPay.Core.Entities;
using ProPay.Core.Interfaces;
using ProPay.SharedKernel.Interfaces;
using System.Threading.Tasks;

namespace ProPay.Core.Services
{
    public class PostPaymentHandler
    {
        private readonly ICheapPaymentGateway _cheapPayment;
        private readonly IExpensivePaymentGateway _expensivePayment;
        private readonly IPremiumPaymentService _premiumPayment;
        private const int MAXPREMIUMPAYMENTRETRY = 3;
        private const int MAXEXPENSIVEPAYMENTRETRY = 1;

        public PostPaymentHandler(ICheapPaymentGateway cheapPayment, IExpensivePaymentGateway expensivePayment, IPremiumPaymentService premiumPayment)
        {
            _cheapPayment = cheapPayment;
            _expensivePayment = expensivePayment;
            _premiumPayment = premiumPayment;
        }

        // configure the usage of the payment services
        public  async Task<bool> Handle(PaymentRequest request)
        {
            var taskStatus = false;
            if(request.Amount <= 20)
            {
                taskStatus = await HandleCheapPayment(request);
            }
            else if ((request.Amount > 20) && (request.Amount <= 500))
            {
                taskStatus = await HandleExpensivePayment(request);
            }
            else if (request.Amount > 500)
            {
                taskStatus = await HandlePremiumPayment(request);
            }

            return taskStatus;
        }


        private async Task<bool> HandleCheapPayment(PaymentRequest request)
        {
            var cheapPayStatus = false;
            try{
                cheapPayStatus =  await _cheapPayment.AcceptPayment(request.Amount, request.CreditCardNumber, request.ExpirationDate, request.SecurityCode);
            }
            catch
            {

            }
            return cheapPayStatus;
        }

        private async Task<bool> HandleExpensivePayment(PaymentRequest request)
        {
            var expensivePayStatus = false;
            var retries = 0;
            try
            {

                while (retries < MAXEXPENSIVEPAYMENTRETRY)
                {
                    expensivePayStatus = await _expensivePayment.AcceptPayment(request.Amount, request.CreditCardNumber, request.ExpirationDate, request.SecurityCode);
                    if (expensivePayStatus) break;
                    retries++;
                }
                if (!expensivePayStatus) expensivePayStatus = await HandleCheapPayment(request);

            }
            catch
            {

            }
            return expensivePayStatus;
        }

        private async Task<bool> HandlePremiumPayment(PaymentRequest request)
        {
            var premiumPayStatus = false;
            var retries = 0;
            try
            {
                while(retries< MAXPREMIUMPAYMENTRETRY)
                {
                    premiumPayStatus = await _premiumPayment.AcceptPayment(request.Amount, request.CreditCardNumber, request.ExpirationDate, request.SecurityCode);
                    if (premiumPayStatus) break;
                    retries++;
                }
            }
            catch
            {

            }
            return premiumPayStatus;
        }

    }
}
