using Confluent.Kafka;
using System.Text.Json;

namespace BikeRentalPoint.Infrastructure.Kafka.Deserializers;

/// <summary>
/// Custom Kafka deserializer for converting message values from JSON format to collections of rental contracts
/// </summary>
public class BikeRentalPointKeyDeserializer : IDeserializer<Guid>
{
    /// <summary>
    /// Deserializes a Kafka message value from JSON format to a list of rental contracts
    /// </summary>
    /// <param name="data">The binary data containing the serialized list of rental contracts</param>
    /// <param name="isNull">Indicates whether the data represents a null value</param>
    /// <param name="context">Context information about the serialization operation</param>
    /// <returns>A list of <see cref="CreateRentDto"/> objects; returns empty list for null input</returns>
    public Guid Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context) =>
        JsonSerializer.Deserialize<Guid>(data);
}