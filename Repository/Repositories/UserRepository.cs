using BO.Models;
using DAO;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetAllUsers() => await UserDAO.Instance.GetAllUsers();
    }
}
