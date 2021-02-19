using ProPay.SharedKernel;
using System.Threading.Tasks;

namespace ProPay.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}