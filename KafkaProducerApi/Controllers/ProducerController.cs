using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace KafkaProducerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProducerController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(string), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Post([FromQuery] string msg)
    {
        return Created("", SendMessageByKafka(msg));
    }


    public IActionResult Get(string msg)
    {
        return Created("", SendMessageByKafka(msg));
    }


    private string SendMessageByKafka(string message)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                var sendResult = producer
                                    .ProduceAsync("fila_produto", new Message<Null, string> { Value = message })
                                        .GetAwaiter()
                                            .GetResult();

                return $"Mensagem '{sendResult.Value}' de '{sendResult.TopicPartitionOffset}'";
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }

        return string.Empty;
    }
}