using System;

namespace AbpSevenDemo.Customers;

[Serializable]
public class CustomerExcelDownloadTokenCacheItem
{
    public string Token { get; set; }
}