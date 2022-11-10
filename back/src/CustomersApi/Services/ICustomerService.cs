using CustomersApi.Models;

namespace CustomersApi.Services;

public interface ICustomerService
{
  Task<IEnumerable<Customer>> GetAll();
  Task<Customer> GetById(int id);
  Task<Customer> GetByName(string name);
  Task Create(Customer customer);
  Task Update(Customer customer);
  Task Delete(Customer customer);
}