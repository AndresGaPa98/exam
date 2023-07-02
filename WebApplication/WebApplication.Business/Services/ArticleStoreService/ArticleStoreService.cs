using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Models;
using WebApplication.Business.Services.StoreService;
using WebApplication.Data.Repositories;
using WebApplication.Entities.Entities;

namespace WebApplication.Business.Services.ArticleStoreService
{
    public  class ArticleStoreService : IArticleStoreService
    {
        private readonly IGenericRepository<ArticleStore> _repository;

        public ArticleStoreService(IGenericRepository<ArticleStore> repo)
        {
            this._repository = repo;
        }


        public async Task<bool> Delete(int ArticleId)
        {
            return await this._repository.Delete(ArticleId);
        }

        public async Task<ArticleStorePaginationModel> GetPagination(PaginationModel model)
        {
            var query = (await this._repository.GetAll()).Where(x => x.StoreId == model.Id.Value);

            var response = new ArticleStorePaginationModel()
            {
                Data = await query
                .Select(x => new ArticleStoreGetModel
                {
                    Id = x.Id,
                    StoreId = x.StoreId,
                    ArticleId = x.ArticleId,
                    Date = x.Date,
                    Article = new ArticleUpdateModel()
                    {
                        Id = x.ArticleId,
                        Code = x.Article.Code,
                        Description = x.Article.Description,
                        Price = x.Article.Price,
                        Stock = x.Article.Stock,
                        UrlImage = x.Article.UrlImage
                    }
                    
                }).Skip(model.Index).Take(model.Size).ToListAsync(),
                Total = query.Count()
            };
            return response;
        }
        public async Task<ArticleStorePaginationModel> GetAllPagination(PaginationModel model)
        {
            var query = await this._repository.GetAll();

            var response = new ArticleStorePaginationModel()
            {
                Data = await query
                .Select(x => new ArticleStoreGetModel
                {
                    Id = x.Id,
                    StoreId = x.StoreId,
                    ArticleId = x.ArticleId,
                    Date = x.Date,
                    Article = new ArticleUpdateModel()
                    {
                        Id = x.ArticleId,
                        Code = x.Article.Code,
                        Description = x.Article.Description,
                        Price = x.Article.Price,
                        Stock = x.Article.Stock,
                        UrlImage = x.Article.UrlImage
                    }

                }).Skip(model.Index).Take(model.Size).ToListAsync(),
                Total = query.Count()
            };
            return response;
        }

        public async Task<ArticleStore> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<ArticleStore> Insert(ArticleStore model)
        {
            return await this._repository.Insert(model);
        }

        public async Task<ArticleStore> Update(ArticleStore model)
        {
            return await this._repository.Update(model);
        }
    }
}
