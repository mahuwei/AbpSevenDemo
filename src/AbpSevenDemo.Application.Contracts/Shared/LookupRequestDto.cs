using Volo.Abp.Application.Dtos;

namespace AbpSevenDemo.Shared; 

public class LookupRequestDto : PagedResultRequestDto
{
    public string Filter { get; set; }

    public LookupRequestDto()
    {
        MaxResultCount = MaxMaxResultCount;
    }
}