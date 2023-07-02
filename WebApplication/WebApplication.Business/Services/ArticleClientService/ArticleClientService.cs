using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Models;
using WebApplication.Business.Services.ArticleStoreService;
using WebApplication.Data.Repositories;
using WebApplication.Entities.Entities;

namespace WebApplication.Business.Services.ArticleClientService
{
    public class ArticleClientService : IArticleClientService
    {
        private readonly IGenericRepository<ArticleClient> _repository;

        public ArticleClientService(IGenericRepository<ArticleClient> repo)
        {
            this._repository = repo;
        }

        public async Task<bool> Delete(int Id)
        {
            return await this._repository.Delete(Id);
        }

        public async Task<IQueryable<ArticleClient>> GetAll()
        {
            return await this._repository.GetAll();
        }

        public async Task<ArticleClient> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<ArticleClientCountModel> GetCount(PaginationModel model)
        {
            var query = (await this._repository.GetAll()).Where(x => x.ClientId == model.ClientId);

            var response = new ArticleClientCountModel()
            {
                Total = query.Count()
            };
            return response;
        }

        public async Task<ArticleClientPaginationModel> GetPagination(PaginationModel model)
        {
            var query = (await this._repository.GetAll()).Where(x => x.ClientId == model.ClientId);

            var response = new ArticleClientPaginationModel()
            {
                Data = await query
                .Select(x => new ArticleClientGetModel
                {
                    Id = x.Id,
                    ArticleId = x.ArticleId,
                    Date = x.Date,
                    Article = new ArticleUpdateModel()
                    {
                        Id = x.ArticleId,
                        Code = x.Article.Code,
                        Description = x.Article.Description,
                        Price = x.Article.Price,
                        Stock = x.Article.Stock,
                        UrlImage = x.Article.UrlImage,
                        Amount = x.Amount
                    }

                }).Skip(model.Index).Take(model.Size).ToListAsync(),
                Total = query.Count()
            };
            return response;
        }

        public async Task<ArticleClient> Insert(ArticleClient model)
        {
            return await this._repository.Insert(model);
        }

        public async Task<ArticleClient> Update(ArticleClient model)
        {
            return await this._repository.Update(model);
        }

    }
}
