using DataLayer.Entities;
using BusinessLayer.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class TagService : ITagService
    {
        private readonly IGenericRepository<Tag> _tagRepository;
        private readonly IGenericRepository<NewsTag> _newsTagRepository;

        public TagService(
            IGenericRepository<Tag> tagRepository,
            IGenericRepository<NewsTag> newsTagRepository)
        {
            _tagRepository = tagRepository;
            _newsTagRepository = newsTagRepository;
        }

        private async Task<bool> IsTagNameUnique(string tagName, string? excludeId = null)
        {
            var existingTag = await _tagRepository.GetAsync(t => t.TagName == tagName);
            return existingTag == null || (existingTag.Id == excludeId);
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync(Expression<Func<Tag, bool>>? filter = null)
        {
            return await _tagRepository.GetAllAsync(filter);
        }

        public async Task<Tag?> GetTagByIdAsync(string id)
        {
            return await _tagRepository.GetAsync(t => t.Id == id);
        }

        public async Task CreateTagAsync(Tag tag)
        {
            if (!await IsTagNameUnique(tag.TagName))
            {
                throw new Exception("Tag with this name already exists.");
            }
            await _tagRepository.CreateAsync(tag);
            await _tagRepository.SaveAsync();
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            var existingTag = await _tagRepository.GetAsync(t => t.Id == tag.Id);
            if (existingTag == null)
            {
                throw new Exception("Tag not found.");
            }

            if (existingTag.TagName != tag.TagName && !await IsTagNameUnique(tag.TagName, tag.Id))
            {
                throw new Exception("Another tag with this name already exists.");
            }

            existingTag.TagName = tag.TagName;
            existingTag.Note = tag.Note;
            existingTag.UpdatedAt = DateTime.UtcNow;

            await _tagRepository.UpdateAsync(existingTag);
            await _tagRepository.SaveAsync();
        }

        public async Task DeleteTagAsync(string id)
        {
            var tag = await _tagRepository.GetAsync(t => t.Id == id);
            if (tag == null)
            {
                throw new Exception("Tag not found.");
            }

            var hasNewsTags = await _newsTagRepository.GetAllAsync(nt => nt.TagId == id);
            if (hasNewsTags.Any())
            {
                throw new Exception("Cannot delete tag as it is associated with news articles.");
            }

            await _tagRepository.RemoveAsync(tag);
            await _tagRepository.SaveAsync();
        }
    }
}