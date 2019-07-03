using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YORed.Domain.Entites
{
    public enum UserRole
    {
        User,
        Moderator,
        Admin
    }
    public class User
    {
        [BsonId]
        public string Id { get; set; }
        public Login Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }

    public class Login
    {
        public Login(string phone)
        {
            Phone = phone;
        }
        public string Phone { get; }
    }
}
