using App.Core.Entities;
using System.Collections.Generic;

namespace App.Core.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User GetById(string id);
        User Create(User user, string password);
    }
}
