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
    public class ArticleClientRepository : IGenericRepository<ArticleClient>
    {
        private readonly AppDbContext _context;
        public ArticleClientRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                ArticleClient model = await this._context.ArticleClients
                        .FirstAsync(c => c.Id == id);
                this._context.ArticleClients.Remove(model);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IQueryable<ArticleClient>> GetAll()
        {
            IQueryable<ArticleClient> query = this._context.ArticleClients;
            return query;
        }

        public async Task<ArticleClient> GetById(int id)
        {
            ArticleClient model = null;
            try
            {
                model = await this._context.ArticleClients.FirstAsync(x => x.Id == id);
                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<ArticleClient> Insert(ArticleClient model)
        {
            try
            {
                await this._context.ArticleClients.AddAsync(model);
                await this._context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                model = null;
                return model;
            }
        }

        public async Task<ArticleClient> Update(ArticleClient model)
        {
            try
            {
                this._context.ArticleClients.Update(model);
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
