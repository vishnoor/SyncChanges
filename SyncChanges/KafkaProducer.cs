using Confluent.Kafka;
using NLog;
using System;
using System.Threading.Tasks;

// Producer example
public class KafkaProducer
{
    private readonly ProducerConfig _config;
    static readonly Logger Log = LogManager.GetCurrentClassLogger();

    public KafkaProducer(string bootstrapServer)
    {
        _config = new ProducerConfig
        {
            BootstrapServers = bootstrapServer
        };
    }

    public async Task ProduceMessage(string topic, string message)
    {
        using var producer = new ProducerBuilder<Null, string>(_config).Build();
        try
        {
            var result = await producer.ProduceAsync(topic, new Message<Null, string>
            {
                Value = message
            });

            Log.Info($"Delivered '{result.Value}' to '{result.TopicPartitionOffset}'");
        }
        catch (ProduceException<Null, string> e)
        {
            Log.Error($"Delivery failed: {e.Error.Reason}");
        }
    }
}
