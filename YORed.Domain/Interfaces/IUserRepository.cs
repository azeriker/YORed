using System.Collections;
using System.Collections.Generic;
using YORed.Domain.Entities;

namespace YORed.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);

        IEnumerable<User> Get();

        User Get(string id);

        void Update(User user);

        bool Exists(string phone, string password);
    }
}
