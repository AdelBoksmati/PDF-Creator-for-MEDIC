using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MEDIC5.Models;

namespace MEDIC5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }


        [HttpPost(Name = "CheckDetails")]
        public ActionResult Details(string name, string email, string password, string confirmPassword, string phoneNumber, string address, string city, string province, string zipCode, string country, string dateOfBirth)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(province) || string.IsNullOrEmpty(zipCode) || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(dateOfBirth))
            {
                return BadRequest("Missing required fields");
            }
            //Additional validation and business logic goes here.
            return Ok("This worked");
        }


    }
}
