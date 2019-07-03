using YORed.Domain.Entities;
using YORed.Domain.Infrastructure;

namespace YORed.Domain.Interfaces
{
    public interface IUserService
    {
        User GetByLogin(string login);

        OperationResult Login(string phone, string password);
    }
}
