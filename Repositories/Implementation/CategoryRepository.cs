using CodePluse.API.Data;
using CodePluse.API.Models.Domain;
using CodePluse.API.Repositories.Interface;

namespace CodePluse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
             _dbContext = dbContext;
        }
        public async Task<Category> CategoryAsync(Category category)
        {
            await _dbContext.Categorys.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }
    }
}
