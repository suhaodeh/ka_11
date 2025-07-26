using KASHOP.DAL.Models;

namespace KASHOP.DAL.Repositories
{
    public interface ICategoryRepository
    {
        int add(Category category);
        IEnumerable<Category> GetAll( bool withTracking= false);
        int Remove(Category category);
        int Update(Category category);
        Category? GetById(int id);
    }
}