using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Models;
using WebApplication.Data.Repositories;
using WebApplication.Entities.Entities;

namespace WebApplication.Business.Services.StoreService
{
    
    public class StoreService : IStoreService
    {
        private readonly IGenericRepository<Store> _repository;

        public StoreService(IGenericRepository<Store> repo)
        {
            this._repository = repo;
        }
        public async Task<bool> Delete(int id)
        {
            return await this._repository.Delete(id);
        }

        public async Task<StorePaginationModel> GetPagination(PaginationModel model)
        {
            var query = await this._repository.GetAll();

            var response = new StorePaginationModel() {
                Data = await query.
                Select(x => new StoreUpdateModel
                {
                    StoreId = x.StoreId,
                    Address = x.Address,
                    BranchName = x.BranchName,
                }).Skip(model.Index).Take(model.Size).ToListAsync(),
                Total = query.Count()
            };
            return response;
        }

        public async Task<Store> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Store> Insert(Store model)
        {
            return await this._repository.Insert(model);
        }

        public async Task<Store> Update(Store model)
        {
            return await this._repository.Update(model);
        }
    }
}
