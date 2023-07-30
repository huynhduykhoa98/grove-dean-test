using Microsoft.AspNetCore.Mvc;

namespace GroveDean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {

        private const string API = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&hourly=temperature_2m";
        private readonly ILogger<WeatherController> _logger;
        private readonly HttpClient _client;

        public WeatherController(ILogger<WeatherController> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        public async Task<Weather?> Get(string latitude, string longitude)
        {
            try
            {
                if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
                {
                    return null;
                }
                var request = new HttpRequestMessage(HttpMethod.Get, string.Format(API, latitude, longitude));
                var result = await _client.SendAsync(request);
                var rs = await result.Content.ReadFromJsonAsync<Weather>();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}