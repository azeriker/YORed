using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

using YORed.Domain.Entities;

namespace YORed.Domain.Repositories
{
    public class MongoContext
    {
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

        public IMongoCollection<Report> Reports => _database.GetCollection<Report>("Reports");

        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoConnection").Value;
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoCollection<TModel> GetCollection<TModel>(string collectionName)
        {
            return _database.GetCollection<TModel>(collectionName);
        }
    }
}
