using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using WebApplication.Business.Models;
using WebApplication.Business.Services.ArticleClientService;
using WebApplication.Business.Services.ArticleStoreService;
using WebApplication.Entities.Entities;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleClientController : BaseController
    {
        private readonly IArticleClientService _articleClientService;
        public ArticleClientController(IArticleClientService articleClientService)
        {
            this._articleClientService = articleClientService;
        }
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(ArticleClientModel request)
        {
            try
            {
                ArticleClient articleClient = new ArticleClient()
                {
                    ArticleId = request.ArticleId,
                    Amount = request.Amount,
                    ClientId = request.ClientId,
                    Date = DateTime.Now
                };
                var result = await this._articleClientService.Insert(articleClient);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(ArticleClientUpdateModel request)
        {
            try
            {
                ArticleClient articleClient = new ArticleClient()
                {
                    Id = request.Id,
                    ArticleId = request.ArticleId,
                    Amount = request.Amount,
                    ClientId = request.ClientId,
                    Date = DateTime.Now
                };
                var result = await this._articleClientService.Update(articleClient);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = await this._articleClientService.Delete(Id);

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
                model.ClientId = USER_ID;
                var result = await this._articleClientService.GetPagination(model);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet("getCount")]
        public async Task<IActionResult> GetCount()
        {
            try
            {
                PaginationModel model = new()
                {
                    ClientId = USER_ID
                };
                var result = await this._articleClientService.GetCount(model);

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
