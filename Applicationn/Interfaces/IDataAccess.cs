using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Applicationn.Interfaces
{
    public interface IDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionStringName, bool isStoredProcedure = false);
        Task<int> SaveDataAsync<T>(string sqlStatement, T parameters, string connectionStringName, bool isStoredProcedure = false);
    }
}
