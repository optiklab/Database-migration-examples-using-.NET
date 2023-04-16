using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phi.Repository.Postgres.Dapper
{
    public interface IDbService
    {
        Task<T> GetAsync<T>(string command, object parms);
        Task<List<T>> GetAll<T>(string command, object parms);
        Task<T> Insert<T>(string command, object parms);
        Task<T> Update<T>(string command, object parms);
        Task<T> Delete<T>(string command, object parms);
    }
}
