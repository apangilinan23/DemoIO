namespace DemoIO.Database
{
    public class ClientAddress
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Foreign key
        public Address Address { get; set; }
    }
}
