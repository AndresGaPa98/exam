using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Models;
using WebApplication.Entities.Entities;


namespace WebApplication.Business.Services.StoreService
{
    public interface IStoreService
    {
        Task<Store> Insert(Store model);
        Task<Store> Update(Store model);
        Task<bool> Delete(int id);
        Task<Store> GetById(int id);
        Task<StorePaginationModel> GetPagination(PaginationModel model);
    }
}
