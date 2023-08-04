namespace Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(CustomerId id);

        Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}