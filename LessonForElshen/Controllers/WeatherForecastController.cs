using LessonForElshen.Entities;
using LessonForElshen.RequestTypes;
using Microsoft.AspNetCore.Mvc;

namespace LessonForElshen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    

    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name="category")]
        public string AddCategory([FromBody] CategoryRequest request)
        {
            try
            {
                var newCategory = new Category()
                {
                    Title = request.Title,
                };
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }
            catch
            {
                return "Aye bu nedir";
            }

            ;
            return "Ash";
        }
    }
}
