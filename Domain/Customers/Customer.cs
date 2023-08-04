using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;

public sealed class Customer : AggregateRoot
{
    public Customer(CustomerId id, string name, string lastName, string email, PhoneNumber phoneNumber, Address address)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        Active = true;
    }

    private Customer() { }

    public CustomerId Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string FullName => $"{Name} {LastName}";
    public string Email { get; private set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public bool Active { get; set; }
}