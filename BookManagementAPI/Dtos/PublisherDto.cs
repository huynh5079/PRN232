using BookManagementAPI.Models;

namespace BookManagementAPI.Dtos
{
    public class PublisherDto
    {
        public string Name { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
