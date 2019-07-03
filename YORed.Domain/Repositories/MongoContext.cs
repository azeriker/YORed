using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using YORed.Domain.Entities;

namespace YORed.Domain.Repositories
{
    public class MongoContext
    {
        public IMongoCollection<User> Users => database.GetCollection<User>("Users");

        public IMongoCollection<PromotionModel> Promotions => database.GetCollection<PromotionModel>("Promotions");

        public IMongoCollection<Plan> Plans => database.GetCollection<Plan>("Plans");

        public IMongoCollection<Option> Options => database.GetCollection<Option>("Options");

        private readonly IMongoDatabase database;

        public MongoContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoConnection").Value;
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(mongoUrl.DatabaseName);

            EnsureSeeded();
        }

        public IMongoCollection<TModel> GetCollection<TModel>(string collectionName)
        {
            return database.GetCollection<TModel>(collectionName);
        }
    }
}
