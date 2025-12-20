namespace DemoIO.Database
{
    public class Address
    {
        public int Id { get; set; }

        public string AddressLine1 { get; set; } = string.Empty;

        public string AddressLine2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        // Navigation property
        public ClientAddress ClientAddress { get; set; }
    }
}
