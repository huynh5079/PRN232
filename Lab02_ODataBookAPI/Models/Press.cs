namespace Lab02_ODataBookAPI.Models
{
    public class Press
    {
        public int PressId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
