using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YORed.Domain.Entities
{
    public enum UserRole
    {
        User,
        Moderator,
        Admin
    }

    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
