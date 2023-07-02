using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Business.Models;
using WebApplication.Business.Services.StoreService;
using WebApplication.Entities.Entities;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            this._storeService = storeService;
        }
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(StoreModel request)
        {
            try
            {
                Store store = new()
                {
                    Address = request.Address,
                    BranchName = request.BranchName,
                };
                var result = await this._storeService.Insert(store);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");
                
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(StoreUpdateModel request)
        {
            try
            {
                Store store = new()
                {
                    StoreId = request.StoreId,
                    Address = request.Address,
                    BranchName = request.BranchName,
                };
                var result = await this._storeService.Update(store);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this._storeService.Delete(id);

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
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await this._storeService.GetById(id);

                if (result is null) throw new Exception("Ha ocurrido un error inesperado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost("getByPagination")]
        public async Task<IActionResult> GetByPagination(PaginationModel model )
        {
            try
            {
                var result = await this._storeService.GetPagination(model);

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
