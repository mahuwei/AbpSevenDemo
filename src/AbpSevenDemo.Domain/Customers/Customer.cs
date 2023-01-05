using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace AbpSevenDemo.Customers
{
    public class Customer : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string MobileNumber { get; set; }

        [CanBeNull]
        public virtual string Email { get; set; }

        public virtual bool IsCompany { get; set; }

        [CanBeNull]
        public virtual string Address { get; set; }

        public Customer()
        {

        }

        public Customer(Guid id, string name, string mobileNumber, string email, bool isCompany, string address)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), CustomerConsts.NameMaxLength, 0);
            Check.NotNull(mobileNumber, nameof(mobileNumber));
            Check.Length(mobileNumber, nameof(mobileNumber), CustomerConsts.MobileNumberMaxLength, 0);
            Check.Length(email, nameof(email), CustomerConsts.EmailMaxLength, 0);
            Check.Length(address, nameof(address), CustomerConsts.AddressMaxLength, 0);
            Name = name;
            MobileNumber = mobileNumber;
            Email = email;
            IsCompany = isCompany;
            Address = address;
        }

    }
}