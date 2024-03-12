using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RansomUserAPI.Controllers
{
    [Route("api/RandomUser")]
    public class RandomUserController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get() 
        {
            return Ok();
        }

        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _randomUserUrl = "https://randomuser.me/api/";

        [HttpGet("GetUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser()
        {
            var response = await _httpClient.GetAsync(_randomUserUrl);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var userData = JsonConvert.DeserializeObject<object>(responseBody);
            return Ok(userData);
        }
    }
}
