using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Data.Repositories
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {

        Task<TEntityModel> Insert(TEntityModel model);
        Task<TEntityModel> Update(TEntityModel model);
        Task<bool> Delete(int id);
        Task<TEntityModel> GetById(int id);
        Task<IQueryable<TEntityModel>> GetAll();
    }
}
