using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IHttpHandler<T> where T : class
    {
        Task<IEnumerable<T>> GetResultsAsync(string endPoint);
    }
}