using System.ComponentModel.DataAnnotations;

namespace CustomersApi.Models;

public class Customer
{
  public int Id { get; set; }

  [Display(Name = "CPF")]
  [StringLength(14, MinimumLength = 11)]
  public string Cpf { get; set; } = default!;

  [Display(Name = "Nome")]
  public string Name { get; set; } = default!;

  [EmailAddress]
  public string Email { get; set; } = default!;

  [Display(Name = "Data de Nascimento")]
  [DataType(DataType.Date)]
  public DateTime Birthday { get; set; }

  [Display(Name = "Sexo")]
  public string Genre { get; set; } = default!;

  [MaxLength(9)]
  [Display(Name = "CEP")]
  public string Cep { get; set; } = default!;

  [Display(Name = "Endereço")]
  public string Address { get; set; } = default!;

  [Display(Name = "Estado")]
  public string State { get; set; } = default!;

  [Display(Name = "Cidade")]
  public string City { get; set; } = default!;
}