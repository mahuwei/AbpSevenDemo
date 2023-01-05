using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace AbpSevenDemo.Customers; 

public class CustomerDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp {
    public string Name {get; set;}
    public string MobileNumber {get; set;}
    public string Email {get; set;}
    public bool IsCompany {get; set;}
    public string Address {get; set;}

    public string ConcurrencyStamp {get; set;}
}