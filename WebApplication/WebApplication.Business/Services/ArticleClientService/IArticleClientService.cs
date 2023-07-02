using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Models;
using WebApplication.Entities.Entities;

namespace WebApplication.Business.Services.ArticleClientService
{
    public interface IArticleClientService
    {
        Task<ArticleClient> Insert(ArticleClient model);
        Task<ArticleClient> Update(ArticleClient model);
        Task<bool> Delete(int Id);
        Task<ArticleClient> GetById(int id);
        Task<ArticleClientPaginationModel> GetPagination(PaginationModel model);
        Task<ArticleClientCountModel> GetCount(PaginationModel model);
    }
}
