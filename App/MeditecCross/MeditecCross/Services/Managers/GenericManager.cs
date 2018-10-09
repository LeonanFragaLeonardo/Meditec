using MeditecCross.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MeditecCross.Services.Managers
{
    public class GenericManager<T> : IGenericAPI<T>
    {
        IGenericAPI<T> genericService;

        public GenericManager(IGenericAPI<T> service)
        {
            genericService = service;
        }

        public Task<List<T>> GetDataListAsync(string resource)
        {
            return genericService.GetDataListAsync(resource);
        }

        public async Task<HttpResponseMessage> SaveAsync(T generic, bool isNew, string resource)
        {
            return await genericService.SaveAsync(generic, isNew, resource);
        }
        public async Task<T> GetById(dynamic id, string resource)
        {
            return await genericService.GetById(id, resource);
        }
        public async Task<T> GetWithPostById(dynamic id, string resource)
        {
            return await genericService.GetWithPostById(id, resource);
        }
        public async Task<List<T>> GetListWithPostById(dynamic id, string resource)
        {
            return await genericService.GetListWithPostById(id, resource);
        }
        public async Task<T> GetWithSecurityAsync(dynamic id, string resource, string authValue)
        {
            return await genericService.GetWithSecurityAsync(id, resource, authValue);
        }
    }
}
