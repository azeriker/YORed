using System;

using YORed.Domain.Infrastructure;
using YORed.Domain.Interfaces;

namespace YORed.Domain.Services
{
    public class UserService : IUserService
    {
        public OperationResult Register(string phone, string password)
        {
            throw new NotImplementedException();
        }

        public OperationResult Login(string phone, string password)
        {
            throw new NotImplementedException();
        }
    }
}
