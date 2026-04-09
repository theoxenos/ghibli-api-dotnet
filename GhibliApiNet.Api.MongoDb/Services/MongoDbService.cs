using GhibliApiNet.Api.MongoDb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GhibliApiNet.Api.MongoDb.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Film> _filmCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _filmCollection = database.GetCollection<Film>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Film>> GetAllFilmsAsync()
    {
        return await _filmCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task CreateAsync(Film film)
    {
    }

    public async Task AddToPlaylistAsync(string id, string movieId)
    {
    }

    public async Task DeleteAsync(string id)
    {
    }
}