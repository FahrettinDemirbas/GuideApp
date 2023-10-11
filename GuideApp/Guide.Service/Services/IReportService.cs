using Guide.Service.Dtos;
using Guide.Service.Models;

namespace Guide.Service.Services
{
    public interface IReportService
    {
        Task<List<ReportDto>> GetAllAsync();
        Task<ReportDto> CreateAsync();   
    }
}
