﻿using System;
using System.Collections.Generic;
using System.Text;
using YORed.Domain.Entities;
using YORed.Domain.Infrastructure;

namespace YORed.Domain.Interfaces
{
    public interface IUserRepository
    {
        OperationResult Create(User user);
        User Get(string id);
        OperationResult Update(User user);
    }
}
