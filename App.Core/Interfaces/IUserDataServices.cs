﻿using App.Core.Entities;

namespace App.Core.Interfaces
{
    public interface IUserDataServices : IRepository<User>
    {
        bool UserNameUsed(string userName);
        User GetUserByName(string username);
    }
}
