using ErrorOr;
using MediatR;

namespace Application.Customers.Create;

public record CreateCustomerCommand(
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    string Line1,
    string Line2,
    string City,
    string ZipCode,
    string State,
    string Country
) : IRequest<ErrorOr<Unit>>;