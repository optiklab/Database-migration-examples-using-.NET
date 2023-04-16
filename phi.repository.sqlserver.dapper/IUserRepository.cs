using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Phi.Repository.SqlServer.Dapper
{
    internal interface IUserRepository
    {
        void Create(User user);
        void Delete(int id);
        User Get(int id);
        List<User> GetUsers();
        void Update(User user);
    }
}
