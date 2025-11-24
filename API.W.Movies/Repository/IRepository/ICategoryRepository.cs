using API.W.Movies.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace API.W.Movies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<bool> CategoryExistByIdAsync(int id);
        Task<bool> CategoryExistsByNameAsync(string name); 
        Task<bool> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
