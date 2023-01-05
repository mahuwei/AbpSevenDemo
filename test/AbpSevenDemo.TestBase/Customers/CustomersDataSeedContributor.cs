using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AbpSevenDemo.Customers;

namespace AbpSevenDemo.Customers
{
    public class CustomersDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CustomersDataSeedContributor(ICustomerRepository customerRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _customerRepository = customerRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _customerRepository.InsertAsync(new Customer
            (
                id: Guid.Parse("b4734520-118a-4d4e-a801-f6c546e529a7"),
                name: "520f80ab686b49e6abd9792ec29a28c5822f6a2f8ccb40b1a4",
                mobileNumber: "50154c086611451692fe",
                email: "6a23b5cb22b441809cc142@5b7e021e448c453c9f3326.com",
                isCompany: true,
                address: "cdb55082e20a49dea3321e749c49d71ea57841cc04264fea8b5b4d472358b2ff6a2506afb01044adbdbfc0e71e6f7a64923055a35a1c4bf798a1d82750ae8db65d1d718362d6435b9f3ce8dbb297167cda55262971b447f8a0bf75d3c3fc286d9be17ac1"
            ));

            await _customerRepository.InsertAsync(new Customer
            (
                id: Guid.Parse("9623a8e8-9491-48ca-bdc8-3fe9e0ad9c13"),
                name: "ec234e82bd204d45894b6dbe757a11ca56286be4d5fe4b19b6",
                mobileNumber: "c74614076a8749018c03",
                email: "aa7803864f9b4584bed6af@95a0b3da0ee64add94dcb4.com",
                isCompany: true,
                address: "6834e4fd83294f908090a4a199714ffa2a0acbe4dcb94a9a9cc5c641e061e47f33000134d6bf401da7f0cefabfa23b5e385b47082c324b39ad7f408ad62d247083e251c46b11495faca9ecda5f824faef8f2f6e1842a40e1b818646af79f4488a6613152"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}