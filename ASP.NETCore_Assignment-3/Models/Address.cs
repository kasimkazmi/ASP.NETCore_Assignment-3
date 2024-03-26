namespace ASP.NETCore_Assignment_3.Models
{
    // Represents an address
    public class Address
    {
        // Unique identifier for the address
        public string Id { get; set; }

        // Street address
        public string Street { get; set; }

        // City
        public string City { get; set; }

        // State or province
        public string State { get; set; }

        // Country
        public string Country { get; set; }

        // Postal code
        public string PostalCode { get; set; }
    }
}
