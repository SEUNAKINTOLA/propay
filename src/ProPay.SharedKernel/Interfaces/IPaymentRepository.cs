using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProPay.SharedKernel.Interfaces
{
    public interface IPaymentRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : BasePaymentEntity;
        Task<List<T>> ListAsync<T>() where T : BasePaymentEntity;
        Task<T> AddAsync<T>(T entity) where T : BasePaymentEntity;
        Task UpdateAsync<T>(T entity) where T : BasePaymentEntity;
        Task DeleteAsync<T>(T entity) where T : BasePaymentEntity;
    }
}