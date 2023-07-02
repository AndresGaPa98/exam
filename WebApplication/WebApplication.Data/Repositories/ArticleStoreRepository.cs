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
    public class ArticleStoreRepository : IGenericRepository<ArticleStore>
    {
        private readonly AppDbContext _context;
        public ArticleStoreRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Article model = await this._context.Articles
                        .FirstAsync(c => c.ArticleId == id);
                this._context.Articles.Remove(model);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IQueryable<ArticleStore>> GetAll()
        {
            IQueryable<ArticleStore> query = this._context.ArticleStores.Include(x => x.Article);
            return query;
        }

        public async Task<ArticleStore> GetById(int id)
        {
            ArticleStore model = null;
            try
            {
                model = await this._context.ArticleStores.FirstAsync(x => x.Id == id);
                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<ArticleStore> Insert(ArticleStore model)
        {
            try
            {
                await this._context.ArticleStores.AddAsync(model);
                await this._context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                model = null;
                return model;
            }
        }

        public async Task<ArticleStore> Update(ArticleStore model)
        {
            try
            {
                this._context.ArticleStores.Update(model);
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
