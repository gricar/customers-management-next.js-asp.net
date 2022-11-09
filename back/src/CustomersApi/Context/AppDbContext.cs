using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Context;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Customer> Customers { get; set; } = default!;
}
