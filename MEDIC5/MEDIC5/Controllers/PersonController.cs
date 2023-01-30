using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MEDIC5.Models;
using MEDIC5.Documents;
using QuestPDF.Fluent;
using System.Diagnostics;

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
        public ActionResult Details([FromBody] Person person)
        {
            if (person == null || string.IsNullOrEmpty(person.Name) || string.IsNullOrEmpty(person.Email) || string.IsNullOrEmpty(person.Password) || string.IsNullOrEmpty(person.ConfirmPassword) || string.IsNullOrEmpty(person.PhoneNumber) || string.IsNullOrEmpty(person.Address) || string.IsNullOrEmpty(person.City) || string.IsNullOrEmpty(person.Province) || string.IsNullOrEmpty(person.ZipCode) || string.IsNullOrEmpty(person.Country) || string.IsNullOrEmpty(person.DateOfBirth))
            {
                return BadRequest("Missing required fields");
            }
            // TODO: Do a better job at validating the model

            var filePath = "PersonDocument.pdf";

            var document = new PersonDoucument(person);
            document.GeneratePdf(filePath);

            Process.Start("explorer.exe", filePath);

            return Ok(new { message = "This worked" });





        }

        



    }
}
