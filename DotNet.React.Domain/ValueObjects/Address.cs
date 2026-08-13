using DotNet.React.Domain.Common;

namespace DotNet.React.Domain.ValueObjects
{
    public sealed record Address
    {
        public string Country { get; }
        public string State { get; }
        public string City { get; }
        public string Street { get; }
        public string PostalCode { get; }

        public Address(
            string country,
            string state,
            string city,
            string street,
            string postalCode)
        {
            if (string.IsNullOrWhiteSpace(country))
                throw new DomainException("Country is required.");

            if (string.IsNullOrWhiteSpace(city))
                throw new DomainException("City is required.");

            Country = country;
            State = state;
            City = city;
            Street = street;
            PostalCode = postalCode;
        }
    }
}
