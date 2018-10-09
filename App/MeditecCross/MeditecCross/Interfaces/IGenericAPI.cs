using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MeditecCross.Interfaces
{
    public interface IGenericAPI<T>
    {
        Task<List<T>> GetDataListAsync(string resource);
        Task<HttpResponseMessage> SaveAsync(T generic, bool isNew, string resource);
        Task<T> GetById(dynamic id, string resource);
        Task<T> GetWithPostById(dynamic id, string resource);
        Task<List<T>> GetListWithPostById(dynamic id, string resource);
        Task<T> GetWithSecurityAsync(dynamic id, string resource, string authValue);
        /*Task<List<object>> GetList();
        Task<object> SaveCodeAsync(object aca, bool isNew);*/
    }
}
