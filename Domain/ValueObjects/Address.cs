namespace Domain.ValueObjects
{
    public partial record Address
    {
        public Address(string line1, string line2, string city, string zipCode, string state, string country)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            ZipCode = zipCode;
            State = state;
            Country = country;
        }

        public string Line1 { get; init; }
        public string Line2 { get; init; }
        public string City { get; init; }
        public string ZipCode { get; init; }
        public string State { get; init; }
        public string Country { get; init; }

        public static Address? Create(string line1, string line2, string city, string zipCode, string country, string state)
        {
            if (string.IsNullOrEmpty(line1) || string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(zipCode) || string.IsNullOrEmpty(country) ||
                string.IsNullOrEmpty(state))
            {
                return null;
            }

            return new Address(line1, line2, city, zipCode, country, state);
        }
    }
}