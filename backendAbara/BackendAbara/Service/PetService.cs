using BackendAbara.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BackendAbara.Services;

public class PetService
{
    private readonly IMongoCollection<Pet> _petCollection;
    public PetService(IOptions<PetsDatabaseSetting> petCollectionSetting)
    {
        var mongoClient = new MongoClient(
            petCollectionSetting.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            petCollectionSetting.Value.DatabaseName);
        _petCollection = mongoDatabase.GetCollection<Pet>(
            petCollectionSetting.Value.PetsCollectionName);
    }

    public async Task<List<Pet>> GetAsync() =>
        await _petCollection.Find(_ => true).ToListAsync();

    // didnt get to the conroller part of summing the ages
    public async Task SumAsync()
    {
        var listSum = await _petCollection.Find(_ => true).ToListAsync();
        listSum.Sum(x => x.Age);

    }
    public async Task CreateAsync(Pet newPet) =>
        await _petCollection.InsertOneAsync(newPet);

}
