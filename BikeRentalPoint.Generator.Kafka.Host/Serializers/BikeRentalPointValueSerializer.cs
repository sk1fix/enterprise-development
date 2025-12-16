using BikeRentalPoint.Application.Contracts.Rent;
using Confluent.Kafka;
using System.Text.Json;

namespace BikeRentalPoint.Generator.Kafka.Host.Serializers;

/// <summary>
/// Serializes a collection of <see cref="CreateRentDto"/> instances to JSON for use as a Kafka message value
/// </summary>
public class BikeRentalPointValueSerializer : ISerializer<IList<CreateRentDto>>
{
    /// <summary>
    /// Converts the provided list of <see cref="CreateRentDto"/> to a UTF-8 encoded JSON byte array suitable for Kafka transport
    /// </summary>
    /// <param name="data">The collection of rent DTOs to serialize</param>
    /// <param name="context">Kafka serialization context containing metadata about the message</param>
    /// <returns>A UTF-8 encoded JSON byte array representing the rent list</returns>
    public byte[] Serialize(IList<CreateRentDto> data, SerializationContext context) =>
        JsonSerializer.SerializeToUtf8Bytes(data);
}
