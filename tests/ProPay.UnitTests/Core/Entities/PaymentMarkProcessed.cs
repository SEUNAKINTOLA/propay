using ProPay.Core.Entities;
using System.Linq;
using Xunit;

namespace ProPay.UnitTests.Core.Entities
{
    public class PaymentMarkProcessed
    {
        [Fact]
        public void SetsIsDoneToTrue()
        {
            var item = new PaymentDetailsBuilder()
                .WithDefaultValues()
                .Amount(20)
                .Build();

            item.MarkDone();

            Assert.True(item.PaymentState == "processed");
        }
    }
}
