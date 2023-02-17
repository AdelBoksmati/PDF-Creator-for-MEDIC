﻿using Microsoft.AspNetCore.Http;
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


        [HttpPost("CheckDetails")]
        public async Task<ActionResult> Details([FromBody] Person person)
        {

            // TODO: Do a better job at validating the model
            if (person == null || string.IsNullOrEmpty(person.Name) || string.IsNullOrEmpty(person.Email) || string.IsNullOrEmpty(person.Password) || string.IsNullOrEmpty(person.ConfirmPassword) || string.IsNullOrEmpty(person.PhoneNumber) || string.IsNullOrEmpty(person.Address) || string.IsNullOrEmpty(person.City) || string.IsNullOrEmpty(person.Province) || string.IsNullOrEmpty(person.ZipCode) || string.IsNullOrEmpty(person.Country) || string.IsNullOrEmpty(person.DateOfBirth))
            {
                return BadRequest("Missing required fields");
            }

            // Generate the PDF document
            var document = new PersonDocument(person);

            // Get the PDF file bytes
            var fileBytes = document.GeneratePdf();

            // Set the response headers
            Response.Headers.Add("Content-Disposition", "attachment; filename=PersonDocument.pdf");
            Response.ContentType = "application/pdf";

            // Write the file bytes to the response stream
            await Response.Body.WriteAsync(fileBytes, 0, fileBytes.Length);

            return Ok(new { message = "This worked" });
            
        }


        [HttpPost("GeneratePDFSavedToSever")]
        public ActionResult Details2([FromBody] Person person)
        {

            // TODO: Do a better job at validating the model
            if (person == null || string.IsNullOrEmpty(person.Name) || string.IsNullOrEmpty(person.Email) || string.IsNullOrEmpty(person.Password) || string.IsNullOrEmpty(person.ConfirmPassword) || string.IsNullOrEmpty(person.PhoneNumber) || string.IsNullOrEmpty(person.Address) || string.IsNullOrEmpty(person.City) || string.IsNullOrEmpty(person.Province) || string.IsNullOrEmpty(person.ZipCode) || string.IsNullOrEmpty(person.Country) || string.IsNullOrEmpty(person.DateOfBirth))
            {
                return BadRequest("Missing required fields");
            }

            // This is the file creation part.
            var filePath = "PersonDocument.pdf";

            // This then creates the PersonDocument passing the person object that came through the validation
            var document = new PersonDocument(person);
            document.GeneratePdf(filePath);

            // Opens the PDF
            Process.Start("explorer.exe", filePath);

            return Ok(new { message = "This worked" });

        }

    }
}
