using Confluent.Kafka;
using System.Text.Json;
namespace BikeRentalPoint.Generator.Kafka.Host.Serializers;

/// <summary>
/// Serializes a <see cref="Guid"/> value to JSON for use as a Kafka message key
/// </summary>
public class BikeRentalPointKeySerializer : ISerializer<Guid>
{
    /// <summary>
    /// Converts the provided <see cref="Guid"/> key to a UTF-8 encoded JSON byte array suitable for Kafka transport
    /// </summary>
    /// <param name="data">The Kafka message key to serialize</param>
    /// <param name="context">Kafka serialization context containing metadata about the message</param>
    /// <returns></returns>
    public byte[] Serialize(Guid data, SerializationContext context) =>
       JsonSerializer.SerializeToUtf8Bytes(data);
}