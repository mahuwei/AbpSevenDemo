namespace AbpSevenDemo.Customers; 

public class CustomerExcelDownloadDto {
    public string DownloadToken {get; set;}

    public string FilterText {get; set;}

    public string Name {get; set;}
    public string MobileNumber {get; set;}
    public string Email {get; set;}
    public bool? IsCompany {get; set;}
    public string Address {get; set;}
}