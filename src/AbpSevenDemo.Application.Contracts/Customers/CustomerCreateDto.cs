using System.ComponentModel.DataAnnotations;

namespace AbpSevenDemo.Customers; 

public class CustomerCreateDto {
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
}