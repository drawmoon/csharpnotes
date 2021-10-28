using System.Threading.Tasks;
using ApiDocumentSwagger.Entities;

namespace ApiDocumentSwagger.Services
{
    public interface ICategoryService
    {
        Task<Category[]> GetAll();

        Task<Category> Get(string id);

        Task<Category> Post(Category category);

        Task<Category> Put(Category category);

        Task<Category> Delete(string id);
    }
}