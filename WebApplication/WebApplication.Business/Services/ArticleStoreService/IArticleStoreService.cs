using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Models;
using WebApplication.Entities.Entities;

namespace WebApplication.Business.Services.ArticleStoreService
{
    public interface IArticleStoreService
    {
        Task<ArticleStore> Insert(ArticleStore model);
        Task<ArticleStore> Update(ArticleStore model);
        Task<bool> Delete(int ArticleId);
        Task<ArticleStore> GetById(int id);
        Task<ArticleStorePaginationModel> GetPagination(PaginationModel model);
        Task<ArticleStorePaginationModel> GetAllPagination(PaginationModel model);

    }
}
