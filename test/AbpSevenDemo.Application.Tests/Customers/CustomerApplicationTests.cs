using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AbpSevenDemo.Customers
{
    public class CustomersAppServiceTests : AbpSevenDemoApplicationTestBase
    {
        private readonly ICustomersAppService _customersAppService;
        private readonly IRepository<Customer, Guid> _customerRepository;

        public CustomersAppServiceTests()
        {
            _customersAppService = GetRequiredService<ICustomersAppService>();
            _customerRepository = GetRequiredService<IRepository<Customer, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _customersAppService.GetListAsync(new GetCustomersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("b4734520-118a-4d4e-a801-f6c546e529a7")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("9623a8e8-9491-48ca-bdc8-3fe9e0ad9c13")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _customersAppService.GetAsync(Guid.Parse("b4734520-118a-4d4e-a801-f6c546e529a7"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("b4734520-118a-4d4e-a801-f6c546e529a7"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CustomerCreateDto
            {
                Name = "2b8bf69a4adf440a929d9de2ec624cf48fdcad5bf50940a28b",
                MobileNumber = "4ef89c0baa9f4c988059",
                Email = "67789de9c7894519846d95@42ad814da7794c21a22f9e.com",
                IsCompany = true,
                Address = "f9b4ce70608745d6a7b7bb61e5f9d9e8cd7e590ec9d649cdbaf9825b140e82144df38528b2854145b2afaa7717de26e273279a3ca43a4f4799e2bcd82d915bd7766a79bd271a4cf0abf16633410e1f52288eeda99d7f417389da64fb7713e97169b48cd5"
            };

            // Act
            var serviceResult = await _customersAppService.CreateAsync(input);

            // Assert
            var result = await _customerRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("2b8bf69a4adf440a929d9de2ec624cf48fdcad5bf50940a28b");
            result.MobileNumber.ShouldBe("4ef89c0baa9f4c988059");
            result.Email.ShouldBe("67789de9c7894519846d95@42ad814da7794c21a22f9e.com");
            result.IsCompany.ShouldBe(true);
            result.Address.ShouldBe("f9b4ce70608745d6a7b7bb61e5f9d9e8cd7e590ec9d649cdbaf9825b140e82144df38528b2854145b2afaa7717de26e273279a3ca43a4f4799e2bcd82d915bd7766a79bd271a4cf0abf16633410e1f52288eeda99d7f417389da64fb7713e97169b48cd5");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CustomerUpdateDto()
            {
                Name = "e0f076fc42104b60acca06c34ef97cbb4e467eec1fd94d7588",
                MobileNumber = "ef4c9da176bc47d38f16",
                Email = "bba9fb5dd20a41ffada885@da333471de4e4d898afa6b.com",
                IsCompany = true,
                Address = "916b65dd6b434f26826708e4f0fff9ad54c7a6cb436440a7a08960fb5cf2b8870eb5e6890c0545feafb32b0675b0c1f1b52b28d391054c8588c7870c762b9a3f4d7be8d8f659450db01fed001a96d419674a3745cbdf4b5cad1193bcaa1d995df9c7719c"
            };

            // Act
            var serviceResult = await _customersAppService.UpdateAsync(Guid.Parse("b4734520-118a-4d4e-a801-f6c546e529a7"), input);

            // Assert
            var result = await _customerRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("e0f076fc42104b60acca06c34ef97cbb4e467eec1fd94d7588");
            result.MobileNumber.ShouldBe("ef4c9da176bc47d38f16");
            result.Email.ShouldBe("bba9fb5dd20a41ffada885@da333471de4e4d898afa6b.com");
            result.IsCompany.ShouldBe(true);
            result.Address.ShouldBe("916b65dd6b434f26826708e4f0fff9ad54c7a6cb436440a7a08960fb5cf2b8870eb5e6890c0545feafb32b0675b0c1f1b52b28d391054c8588c7870c762b9a3f4d7be8d8f659450db01fed001a96d419674a3745cbdf4b5cad1193bcaa1d995df9c7719c");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _customersAppService.DeleteAsync(Guid.Parse("b4734520-118a-4d4e-a801-f6c546e529a7"));

            // Assert
            var result = await _customerRepository.FindAsync(c => c.Id == Guid.Parse("b4734520-118a-4d4e-a801-f6c546e529a7"));

            result.ShouldBeNull();
        }
    }
}