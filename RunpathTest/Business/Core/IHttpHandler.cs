using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface IHttpHandler<T> where T : class
    {
        Task<IEnumerable<T>> GetResultsAsync();
    }
}