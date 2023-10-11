using AutoMapper;
using Guide.Service.Dtos;
using Guide.Service.Models;
using Guide.Service.Settings;
using MongoDB.Driver;

namespace Guide.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IMongoCollection<Report> _reportCollection;
        private readonly IMapper _mapper;
        public ReportService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _reportCollection = database.GetCollection<Report>(databaseSettings.ReportCollectionName);
            _mapper = mapper;
        }
        public async Task<ReportDto> CreateAsync()
        {
            var report = new Report() { ReportStatu = Enums.ReportStatus.Hazirlaniyor, RequestDate = DateTime.Now };
            await _reportCollection.InsertOneAsync(report);
            return _mapper.Map<ReportDto>(report);
        }
        public async Task<List<ReportDto>> GetAllAsync()
        {
            var reports = await _reportCollection.Find(report => true).ToListAsync();
            return _mapper.Map<List<ReportDto>>(reports);
        }
    }
}
