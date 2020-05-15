using SuperAnimal.Data;
using SuperAnimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public AppUser GetUserById(string userId);
    }
}
