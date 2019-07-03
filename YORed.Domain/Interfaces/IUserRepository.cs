using YORed.Domain.Entities;

namespace YORed.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);

        User Get(string id);

        void Update(User user);

        bool Exists(string phone, string password);
    }
}
