using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace AbpSevenDemo.Customers; 

public class CustomerUpdateDto : IHasConcurrencyStamp {
    [Required]
    [StringLength(CustomerConsts.NameMaxLength)]
    public string Name {get; set;}

    [Required]
    [StringLength(CustomerConsts.MobileNumberMaxLength)]
    public string MobileNumber {get; set;}

    [EmailAddress]
    [StringLength(CustomerConsts.EmailMaxLength)]
    public string Email {get; set;}

    public bool IsCompany {get; set;}

    [StringLength(CustomerConsts.AddressMaxLength)]
    public string Address {get; set;}

    public string ConcurrencyStamp {get; set;}
}