using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using YORed.Domain.Entities;

namespace YORed.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);

        IEnumerable<User> Get();

        User Get(string id);

        User Get<TField>(Expression<Func<User, TField>> field, TField value);

        void Update(User user);

        bool Exists(string phone, string password);
    }
}
