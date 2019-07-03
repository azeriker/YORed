using YORed.Domain.Entities;
using YORed.Domain.Infrastructure;
using YORed.Domain.Interfaces;

namespace YORed.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetByLogin(string login)
        {
            return _userRepository.Get(i => i.Login.Phone, login);
        }

        public OperationResult Login(string phone, string password)
        {
            var success = _userRepository.Exists(phone, password);

            return new OperationResult
            {
                Success = success
            };
        }
    }
}
