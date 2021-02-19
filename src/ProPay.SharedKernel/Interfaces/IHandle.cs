using ProPay.SharedKernel;
using System.Threading.Tasks;

namespace ProPay.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}