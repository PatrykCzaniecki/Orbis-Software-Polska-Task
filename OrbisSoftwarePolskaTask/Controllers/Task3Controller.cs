using System.Globalization;
using System.Net;
using System.Reflection.Metadata;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OrbisSoftwarePolskaTask.Models;
using RestSharp;

namespace OrbisSoftwarePolskaTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Task3Controller : ControllerBase
    {
        private readonly ILogger<Task3Controller> _logger;

        public Task3Controller(ILogger<Task3Controller> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderInvoiceFile(int invoiceId, string externalInvoiceNumber, string filePath)
        {
            var fileToSend = "data:" + (new ExtensionMethods.ExtensionMethods().CharReplacement(await System.IO.File.ReadAllTextAsync(filePath)));
            var baselinkerOrderTask = new BaselinkerOrderTask3(invoiceId, fileToSend, externalInvoiceNumber);
            var restClient = new RestClient("https://api.baselinker.com/connector.php");
            var attemptsCounter = 0;
            while (attemptsCounter < 3)
            {
                try
                {
                    var response =
                        await restClient.PostAsync(
                            new ExtensionMethods.ExtensionMethods().CreateRequest("addOrderInvoiceFile", baselinkerOrderTask));

                    if (response.StatusCode is HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
                    {
                        attemptsCounter++;
                        _logger.LogInformation($"There was an unsuccessful attempt no. {attemptsCounter} out of 3 for this task.");
                        continue;
                    }
                    _logger.LogInformation($"Action success! The content is: {response.Content}");
                    return Ok(response.Content);
                }
                catch (HttpRequestException exception)
                {
                    _logger.LogError($"Error {exception.StatusCode} about the content {exception.Message} appears.");
                    return Problem($"Error {exception.Message} appears.");
                }
            }
            _logger.LogError("Too many attempts to server on this method. Please try again later..");
            return StatusCode(400);
        }
    }
}