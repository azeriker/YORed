using YORed.Domain.Infrastructure;

namespace YORed.Domain.Interfaces
{
    public interface IUserService
    {
        OperationResult Register(string phone, string password);
        OperationResult Login(string phone, string password);
    }
}
