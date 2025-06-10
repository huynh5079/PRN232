using DataLayer.Entities;
using BusinessLayer.Repositories;
using System.Linq.Expressions;

namespace BusinessLayer.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync(Expression<Func<Tag, bool>>? filter = null);
        Task<Tag?> GetTagByIdAsync(string id);
        Task CreateTagAsync(Tag tag);
        Task UpdateTagAsync(Tag tag);
        Task DeleteTagAsync(string id);
    }
}