using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using AbpSevenDemo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpSevenDemo.Customers; 

public class EfCoreCustomerRepository : EfCoreRepository<AbpSevenDemoDbContext, Customer, Guid>,
    ICustomerRepository {
    public EfCoreCustomerRepository(IDbContextProvider<AbpSevenDemoDbContext> dbContextProvider)
        : base(dbContextProvider) {
    }

    public async Task<List<Customer>> GetListAsync(string filterText = null,
        string name = null,
        string mobileNumber = null,
        string email = null,
        bool? isCompany = null,
        string address = null,
        string sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        CancellationToken cancellationToken = default) {
        var query = ApplyFilter(await GetQueryableAsync(), filterText, name, mobileNumber, email,
            isCompany, address);
        query = query.OrderBy(string.IsNullOrWhiteSpace(sorting)
            ? CustomerConsts.GetDefaultSorting(false)
            : sorting);
        return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
    }

    public async Task<long> GetCountAsync(string filterText = null,
        string name = null,
        string mobileNumber = null,
        string email = null,
        bool? isCompany = null,
        string address = null,
        CancellationToken cancellationToken = default) {
        var query = ApplyFilter(await GetDbSetAsync(), filterText, name, mobileNumber, email,
            isCompany, address);
        return await query.LongCountAsync(GetCancellationToken(cancellationToken));
    }

    protected virtual IQueryable<Customer> ApplyFilter(IQueryable<Customer> query,
        string filterText,
        string name = null,
        string mobileNumber = null,
        string email = null,
        bool? isCompany = null,
        string address = null) {
        return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),
                e => e.Name.Contains(filterText)
                     || e.MobileNumber.Contains(filterText)
                     || e.Email.Contains(filterText)
                     || e.Address.Contains(filterText))
            .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
            .WhereIf(!string.IsNullOrWhiteSpace(mobileNumber),
                e => e.MobileNumber.Contains(mobileNumber))
            .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.Contains(email))
            .WhereIf(isCompany.HasValue, e => e.IsCompany == isCompany)
            .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address));
    }
}