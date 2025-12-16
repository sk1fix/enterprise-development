using BikeRentalPoint.Application.Contracts.Rent;
using BikeRentalPoint.Generator.Kafka.Host.Generator;
using BikeRentalPoint.Generator.Kafka.Host.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalPoint.Generator.Kafka.Host.Controllers;

/// <summary>
/// API controller that coordinates generation of fake rent contracts and publishing them to Kafka in configurable batches
/// </summary>
/// <param name="logger">Logger instance used for diagnostic and error logging</param>
/// <param name="producerService">Abstraction over the message producer responsible for sending rent batches</param>
/// <param name="configuration">Application configuration used to resolve bike and renter identifiers</param>
[Route("api/[controller]")]
[ApiController]
public class GeneratorController(ILogger<GeneratorController> logger, IProducerService producerService, IConfiguration configuration) : ControllerBase
{
    /// <summary>
    /// Generates a specified number of fake rent contracts and sends them to Kafka in batches with an optional delay between batches
    /// </summary>
    /// <param name="batchSize">Maximum number of contracts to include in a single batch sent to Kafka</param>
    /// <param name="payloadLimit">Total number of contracts to generate and publish</param>
    /// <param name="waitTime">Delay in seconds to wait between sending consecutive batches</param>
    /// <returns>A list of all generated <see cref="CreateRentDto"/> instances wrapped in an HTTP 200 response on success</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<CreateRentDto>>> Get(
        [FromQuery] int batchSize,
        [FromQuery] int payloadLimit,
        [FromQuery] int waitTime)
    {
        logger.LogInformation("Generating {limit} contracts via {batchSize} batches and {waitTime}s delay", payloadLimit, batchSize, waitTime);

        try
        {
            var list = new List<CreateRentDto>(payloadLimit);
            var counter = 0;

            var bikeIds = (configuration["BikeIds"] ?? "")
                .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(Guid.Parse)
                .ToArray();

            var renterIds = (configuration["RenterIds"] ?? "")
                .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(Guid.Parse)
                .ToArray();

            while (counter < payloadLimit)
            {
                var currentBatchSize = Math.Min(batchSize, payloadLimit - counter);

                var batch = RentGenerator.GenerateLinks(currentBatchSize, bikeIds, renterIds);

                await producerService.SendAsync(batch);

                logger.LogInformation("Batch of {batchSize} items has been sent", currentBatchSize);

                counter += currentBatchSize;
                list.AddRange(batch);

                if (counter < payloadLimit && waitTime > 0)
                    await Task.Delay(waitTime * 1000);
            }

            logger.LogInformation("{method} method of {controller} executed successfully", nameof(Get), GetType().Name);
            return Ok(list);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(Get), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}