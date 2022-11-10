using CustomersApi.Context;
using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Services;

public class CustomerService : ICustomerService
{
  private readonly AppDbContext _context;

  public CustomerService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Customer>> GetAll()
  {
    return await _context.Customers.ToListAsync();
  }

  public async Task<Customer> GetById(int id)
  {
    return await _context.Customers.FindAsync(id)!;
  }

  public async Task<Customer> GetByName(string name)
  {
    IEnumerable<Customer> customers;
    if (!string.IsNullOrWhiteSpace(name))
    {
      customers = await _context.Customers.Where(c => c.Name.Contains(name)).ToListAsync();
    }
    else
    {
      customers = await GetAll();
    }

    return (Customer)customers;
  }

  public async Task Create(Customer customer)
  {
    _context.Customers.Add(customer);
    await _context.SaveChangesAsync();
  }

  public async Task Update(Customer customer)
  {
    _context.Entry(customer).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }

  public async Task Delete(Customer customer)
  {
    _context.Customers.Remove(customer);
    await _context.SaveChangesAsync();
  }
}