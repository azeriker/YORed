using System;
using System.Collections.Generic;
using System.Text;
using YORed.Domain.Infrastructure;

namespace YORed.Domain.Interfaces
{
    public interface IAccountService
    {
        OperationResult Register(string phone, string password);
        OperationResult Login(string phone, string password);
    }
}
