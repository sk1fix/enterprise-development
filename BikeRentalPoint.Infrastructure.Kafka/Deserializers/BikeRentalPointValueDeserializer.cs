using BikeRentalPoint.Application.Contracts.Rent;
using Confluent.Kafka;
using System.Text.Json;

namespace BikeRentalPoint.Infrastructure.Kafka.Deserializers;

/// <summary>
/// Custom Kafka deserializer for converting message keys from JSON format to Guid identifiers
/// </summary>
public class BookStoreValueDeserializer : IDeserializer<IList<CreateRentDto>>
{
    /// <summary>
    /// Deserializes a Kafka message key from JSON format to a Guid
    /// </summary>
    /// <param name="data">The binary data containing the serialized Guid</param>
    /// <param name="isNull">Indicates whether the data represents a null value</param>
    /// <param name="context">Context information about the serialization operation</param>
    /// <returns>A Guid representation of the message key</returns>
    public IList<CreateRentDto> Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        if (isNull) return [];
        return JsonSerializer.Deserialize<IList<CreateRentDto>>(data) ?? [];
    }
}