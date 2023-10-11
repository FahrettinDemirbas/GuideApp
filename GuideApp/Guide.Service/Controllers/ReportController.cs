using Guide.Service.Dtos;
using Guide.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Guide.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<List<ReportDto>> GetAll()
        {
            var reports = await _reportService.GetAllAsync();
            return reports;
        }

        [HttpPost]
        public async Task<ReportDto> Create()
        {
            var reports = await _reportService.CreateAsync();
            return reports;
        }
    }
}
