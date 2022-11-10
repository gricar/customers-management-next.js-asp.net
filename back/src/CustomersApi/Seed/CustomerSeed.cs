using CustomersApi.Context;
using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Seed;

public class CustomerSeed
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using var context = new AppDbContext(
        serviceProvider.GetRequiredService<
            DbContextOptions<AppDbContext>>());
    if (context.Customers.Any())
    {
      return;
    }
    context.Customers.AddRange(
        new Customer
        {
          Cpf = "12345678901",
          Name = "Usuário",
          Email = "usuario@gmail.com",
          Birthday = DateTime.Parse("1996-5-27"),
          Genre = "Masculino",
          Cep = "12235181",
          Address = "Rua Iraci Gonçalves Ferreira",
          State = "São Paulo",
          City = "São José dos Campos",
        },
          new Customer
          {
            Cpf = "98765432109",
            Name = "Usuário_2",
            Email = "usuario_2@yahoo.com",
            Birthday = DateTime.Parse("1988-7-02"),
            Genre = "Feminino",
            Cep = "12233540",
            Address = "Rua Teófilo Otoni",
            State = "São Paulo",
            City = "São José dos Campos",
          }
    );
    context.SaveChanges();
  }
}