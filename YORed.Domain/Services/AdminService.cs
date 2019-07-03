using YORed.Domain.Entities;
using YORed.Domain.Interfaces;

namespace YORed.Domain.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;

        public AdminService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CreateUser(string phone, UserRole role)
        {
            if(!_userRepository.Exists(phone, "123"))
                _userRepository.Create(new User { Login = phone, Password = "123", Role = role });
            
            return true;
        }
    }
}
