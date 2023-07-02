using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Business.Models;
using WebApplication.Business.Services.ArticleStoreService;
using WebApplication.Business.Services.StoreService;
using WebApplication.Entities.Entities;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleStoreController : BaseController
    {
        private readonly IArticleStoreService _articleStoreService;
        public ArticleStoreController(IArticleStoreService articleStoreService)
        {
            this._articleStoreService = articleStoreService;
        }
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(ArticleStoreModel request)
        {
            try
            {
                ArticleStore store = new ArticleStore()
                {
                    StoreId = request.StoreId,
                    Article = new Article
                    {
                        Code = request.Article.Code,
                        Description = request.Article.Description,
                        Price = request.Article.Price,
                        Stock = request.Article.Stock,
                        UrlImage = request.Article.UrlImage
                    },
                    Date = DateTime.Now
                };
                var result = await this._articleStoreService.Insert(store);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(ArticleStoreUpdateModel request)
        {
            try
            {
                ArticleStore store = new ArticleStore()
                {
                    Id = request.Id,
                    StoreId = request.StoreId,
                    ArticleId = request.Article.Id,
                    Article = new Article
                    {
                        ArticleId = request.Article.Id,
                        Code = request.Article.Code,
                        Description = request.Article.Description,
                        Price = request.Article.Price,
                        Stock = request.Article.Stock,
                        UrlImage = request.Article.UrlImage
                    },
                    Date = DateTime.Now
                };
                var result = await this._articleStoreService.Update(store);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("delete/{articleId}")]
        public async Task<IActionResult> Delete(int articleId)
        {
            try
            {
                var result = await this._articleStoreService.Delete(articleId);

                if (!result) throw new Exception("Ha ocurrido un error inesperado");

                ArticleDeleteResponse response = new()
                {
                    Message = "Se ha actualizado la tienda con éxito",
                    Status = true
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("getByPagination")]
        public async Task<IActionResult> GetByPagination(PaginationModel model)
        {
            try
            {
                
                var result = await this._articleStoreService.GetPagination(model);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [AllowAnonymous]
        [HttpPost("getAllByPagination")]
        public async Task<IActionResult> GetAllByPagination(PaginationModel model)
        {
            try
            {
                var result = await this._articleStoreService.GetAllPagination(model);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

    }
}
