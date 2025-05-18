using CodePluse.API.Data;
using CodePluse.API.Models.Domain;
using CodePluse.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePluse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            //this.dbContext=dbContext;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCateory(CreateCategoryRequestDTO requestDTO)
        {
            //Map DTO to Domain Model

            var category = new Category
            {
                Name = requestDTO.Name,
                UrlHandle = requestDTO.UrlHandle,
            };

            await _dbContext.Categorys.AddAsync(category);
            await _dbContext.SaveChangesAsync();


            //Domain model to DTO
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };
            return Ok(response);
        }

    }
}
