using Microsoft.AspNetCore.Mvc;
using ProPay.Core.Entities;
using ProPay.Core.Interfaces;
using ProPay.Core.Services;
using ProPay.SharedKernel.Interfaces;
using ProPay.Web.ApiModels;
using ProPay.Web.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProPay.Web.Api
{
    public class PaymentsController : BaseApiController
    {
        private readonly IPaymentRepository _repository;

        private readonly ICheapPaymentGateway _cheapPayment;
        private readonly IExpensivePaymentGateway _expensivePayment;
        private readonly IPremiumPaymentGateway _premiumPayment;
        public PaymentsController(ICheapPaymentGateway cheapPayment, IExpensivePaymentGateway expensivePayment, IPremiumPaymentGateway premiumPayment, IPaymentRepository repository)
        {
            _cheapPayment = cheapPayment;
            _expensivePayment = expensivePayment;
            _premiumPayment = premiumPayment;
            _repository = repository;
        }



        // POST: api/Payments/ProcessPayment
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestDTO paymentRequest)
        {
            PaymentDetails item = PaymentRequestDTO.PaymentDetailsFromRequest(paymentRequest);
            item.MarkInitiated();
            var postpaymentstatus = await new PostPaymentHandler(_cheapPayment, _expensivePayment, _premiumPayment).Handle(PaymentRequestDTO.GetPaymentRequestEntity(paymentRequest));
            if (postpaymentstatus) item.MarkDone();
            else item.MarkFailed();

            try
            {
                await _repository.AddAsync(item);
            }
            catch
            {
                throw;
            }


            return Ok(item);
        }

    }
}
