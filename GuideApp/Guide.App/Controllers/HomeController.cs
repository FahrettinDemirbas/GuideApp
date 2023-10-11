using Guide.App.Models;
using Guide.App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;

namespace Guide.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RabbitMQPublisher _rabbitMQPublisher;
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger, RabbitMQPublisher rabbitMQPublisher, HttpClient httpClient)
        {
            _logger = logger;
            _rabbitMQPublisher = rabbitMQPublisher;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }  
       
        public async Task<IActionResult> Location()
        {
            var response = await _httpClient.GetAsync($"http://localhost:5175/api/Report/");
            _rabbitMQPublisher.Publish(new GuideReportCreatedEvent() { ReportName = nameof(Location) });
            return RedirectToAction(nameof(Index));
        }
       
        public async Task<IActionResult> RegisteredPerson()
        {
            _rabbitMQPublisher.Publish(new GuideReportCreatedEvent() { ReportName = nameof(RegisteredPerson) });
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> RegisteredPhone()
        {
            _rabbitMQPublisher.Publish(new GuideReportCreatedEvent() { ReportName = nameof(RegisteredPhone) });
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}