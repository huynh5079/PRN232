namespace Lab02_ODataBookAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public int PressId { get; set; }

        public Press Press { get; set; }
    }
}
