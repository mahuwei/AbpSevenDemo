using System;
using AbpSevenDemo.Shared;
using Volo.Abp.AutoMapper;
using AbpSevenDemo.Customers;
using AutoMapper;

namespace AbpSevenDemo;

public class AbpSevenDemoApplicationAutoMapperProfile : Profile
{
    public AbpSevenDemoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, CustomerExcelDto>();
    }
}