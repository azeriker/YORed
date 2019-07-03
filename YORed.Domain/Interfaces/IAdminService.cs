using YORed.Domain.Entities;

namespace YORed.Domain.Interfaces
{
    public interface IAdminService
    {
        bool CreateUser(string phone, UserRole role);
    }
}
