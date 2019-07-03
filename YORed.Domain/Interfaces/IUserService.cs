using YORed.Domain.Infrastructure;

namespace YORed.Domain.Interfaces
{
    public interface IUserService
    {
        OperationResult Login(string phone, string password);
    }
}
