using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace OrbisSoftwarePolskaTask.Controllers;

[ApiController]
[Route("[controller]")]
public class GetOrderController : ControllerBase
{
    private readonly ILogger<GetOrderController> _logger;

    public GetOrderController(ILogger<GetOrderController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:int}", Name = "getOrders")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var restClient = new RestClient("https://api.baselinker.com/connector.php");
        var attemptsCounter = 0;
        while (attemptsCounter < 3)
            try
            {
                var response =
                    await restClient.PostAsync(
                        new ExtensionMethods.ExtensionMethods().CreateRequest("getOrders", id));

                if (response.StatusCode is HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
                {
                    attemptsCounter++;
                    _logger.LogInformation(
                        $"There was an unsuccessful attempt no. {attemptsCounter} out of 3 for this task.");
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

        _logger.LogError("Too many attempts to server on this method. Please try again later..");
        return StatusCode(400);
    }
}