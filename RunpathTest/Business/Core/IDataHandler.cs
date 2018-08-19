using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Business.Core
{
    public interface IDataHandler
    {
        Task<IEnumerable<DataTableModel>> GetDataTableAsync();
    }
}