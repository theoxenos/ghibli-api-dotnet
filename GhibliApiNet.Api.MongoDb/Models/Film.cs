using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GhibliApiNet.Api.MongoDb.Models;

public record Film
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }

    [BsonElement("title")] public string? Title { get; init; }
    [BsonElement("originalTitle")] public string? OriginalTitle { get; init; }

    [BsonElement("originalTitleRomanised")]
    public string? OriginalTitleRomanised { get; init; }

    [BsonElement("image")] public string? Image { get; init; }
    [BsonElement("movieBanner")] public string? MovieBanner { get; init; }
    [BsonElement("description")] public string? Description { get; init; }
    [BsonElement("director")] public string? Director { get; init; }
    [BsonElement("producer")] public string? Producer { get; init; }
    [BsonElement("releaseDate")] public int ReleaseDate { get; init; }
    [BsonElement("runningTime")] public int RunningTime { get; init; }
    [BsonElement("rtScore")] public int RtScore { get; init; }

    [BsonElement("people"), BsonRepresentation(BsonType.ObjectId)]
    public List<string>? People { get; init; } = [];

    [BsonElement("locations"), BsonRepresentation(BsonType.ObjectId)]
    public List<string>? Locations { get; init; } = [];

    [BsonElement("species"), BsonRepresentation(BsonType.ObjectId)]
    public List<string>? Species { get; init; } = [];

    [BsonElement("vehicles"), BsonRepresentation(BsonType.ObjectId)]
    public List<string>? Vehicles { get; init; } = [];

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [BsonElement("__v")]
    public int Version { get; set; }
}