using System;
using System.Collections.Generic;

namespace ProPay.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BasePaymentEntity
    {
        public Guid Id { get; set; }
    }
}