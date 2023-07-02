using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Data.Context;
using WebApplication.Entities.Entities;

namespace WebApplication.Data.Repositories
{
    public class StoreRepository : IGenericRepository<Store>
    {
        private readonly AppDbContext _context;
        public StoreRepository(AppDbContext context)
        {
            this._context = context; 
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Store model = await this._context.Stores.FirstAsync(c => c.StoreId == id);
                this._context.Stores.Remove(model);
                await this._context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IQueryable<Store>> GetAll()
        {
            IQueryable<Store> query = this._context.Stores;
            return query;
        }

        public async Task<Store> GetById(int id)
        {
            Store model = null;
            try
            {
                model = await this._context.Stores.FirstAsync(x => x.StoreId == id);
                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Store> Insert(Store model)
        {
            
            try
            {
                await this._context.Stores.AddAsync(model);
                await this._context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                model = null;

                return model;
            }
        }

        public async Task<Store> Update(Store model)
        {
            try
            {
                this._context.Stores.Update(model);
                await this._context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                model = null;
                return model;
            }
        }
    }
}
