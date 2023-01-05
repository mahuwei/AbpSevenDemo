using Volo.Abp.AutoMapper;
using AbpSevenDemo.Customers;
using AutoMapper;

namespace AbpSevenDemo.Blazor;

public class AbpSevenDemoBlazorAutoMapperProfile : Profile
{
    public AbpSevenDemoBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.

        CreateMap<CustomerDto, CustomerUpdateDto>();
    }
}