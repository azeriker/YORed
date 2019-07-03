using System;
using MongoDB.Driver;
using YORed.Domain.Entities;
using YORed.Domain.Infrastructure;
using YORed.Domain.Interfaces;

namespace YORed.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IMongoCollection<User> _collection;

        public UserRepository(MongoContext context)
        {
            _collection = context.Users;
        }

        public void Create(User user)
        {
            _collection.InsertOne(user);
        }

        public User Get(string id)
        {
            return _collection.Find(i => i.Id == id).FirstOrDefault();
        }

        public bool Exists(string phone, string password)
        {
            return _collection.Find(i => i.Login.Phone == phone && i.Password == password).FirstOrDefault() != null;
        }

        public void Update(User user)
        {
            //var update = Builders<User>.Update
            //    .Set(i => i.Password, customerModel.Balance)
            //    .Set(i => i.OptionIds, customerModel.OptionIds)
            //    .Set(i => i.PlanId, customerModel.PlanId);
            //_collection.UpdateOne(user);
        }
    }
}
