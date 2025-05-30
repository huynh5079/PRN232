namespace BookManagementAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
