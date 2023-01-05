using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Services;

namespace AbpSevenDemo.Customers; 

public class CustomerManager : DomainService {
    private readonly ICustomerRepository _customerRepository;

    public CustomerManager(ICustomerRepository customerRepository) {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> CreateAsync(string name,
        string mobileNumber,
        string email,
        bool isCompany,
        string address) {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.Length(name, nameof(name), CustomerConsts.NameMaxLength);
        Check.NotNullOrWhiteSpace(mobileNumber, nameof(mobileNumber));
        Check.Length(mobileNumber, nameof(mobileNumber), CustomerConsts.MobileNumberMaxLength);
        Check.Length(email, nameof(email), CustomerConsts.EmailMaxLength);
        Check.Length(address, nameof(address), CustomerConsts.AddressMaxLength);

        var customer = new Customer(GuidGenerator.Create(),
            name, mobileNumber, email, isCompany, address);

        return await _customerRepository.InsertAsync(customer);
    }

    public async Task<Customer> UpdateAsync(Guid id,
        string name,
        string mobileNumber,
        string email,
        bool isCompany,
        string address,
        [CanBeNull] string concurrencyStamp = null) {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.Length(name, nameof(name), CustomerConsts.NameMaxLength);
        Check.NotNullOrWhiteSpace(mobileNumber, nameof(mobileNumber));
        Check.Length(mobileNumber, nameof(mobileNumber), CustomerConsts.MobileNumberMaxLength);
        Check.Length(email, nameof(email), CustomerConsts.EmailMaxLength);
        Check.Length(address, nameof(address), CustomerConsts.AddressMaxLength);

        var customer = await _customerRepository.GetAsync(id);

        customer.Name = name;
        customer.MobileNumber = mobileNumber;
        customer.Email = email;
        customer.IsCompany = isCompany;
        customer.Address = address;

        customer.SetConcurrencyStampIfNotNull(concurrencyStamp);
        return await _customerRepository.UpdateAsync(customer);
    }
}