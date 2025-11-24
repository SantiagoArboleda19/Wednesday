using API.W.Movies.DataAccessLayer;
using API.W.Movies.DataAccessLayer.Models;
using API.W.Movies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.W.Movies.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        //Inyeccion de dependencias
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }
        public async Task<bool> CategoryExistByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow;

            await _context.Categories.AddAsync(category);

            return await SaveAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryAsync(id);

            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            return await SaveAsync();
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .OrderBy(c  => c.Name)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow;

            _context.Categories.Update(category);

            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
