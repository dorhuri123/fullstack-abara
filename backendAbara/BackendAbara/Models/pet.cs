using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendAbara.Models;

public class Pet
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [StringLength(25, ErrorMessage = "The pet name cant exceed 25 charcters.")]
    public string Name { get; set; } = null!;
    [Range(0, 20, ErrorMessage = "Age is not negtive and can't exceed 20")]
    public decimal Age { get; set; }

    public string Type { get; set; } = null!;
    public DateTime Created_at { get; set; }
}