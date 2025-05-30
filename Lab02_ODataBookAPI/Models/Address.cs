namespace Lab02_ODataBookAPI.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<Press> Presses { get; set; }
    }
}
