using CustomersApi.Models;
using CustomersApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
  private readonly ICustomerService _customerService;

  public CustomersController(ICustomerService customerService)
  {
    _customerService = customerService;
  }

  [HttpGet]
  public async Task<IActionResult> GetCustomers()
  {
    IEnumerable<Customer> customers = await _customerService.GetAll();
    return Ok(customers);
  }

  [HttpGet("{id:int}", Name = "GetCustomer")]
  public async Task<IActionResult> GetCustomer(int id)
  {
    Customer customer = await _customerService.GetById(id);

    if (customer is null) return NotFound();

    return Ok(customer);
  }

  [HttpGet("{name}")]
  public async Task<IActionResult> GetCustomersByName(string name)
  {
    IEnumerable<Customer> customers = await _customerService.GetByName(name);

    if (customers is null) return NotFound();

    return Ok(customers);
  }

  [HttpPost]
  public async Task<IActionResult> Create([Bind("Id,Cpf,Name,Email,Birthday,Genre,Cep,Address,State,City")] Customer customer)
  {
    if (ModelState.IsValid)
    {
      await _customerService.Create(customer);
      return CreatedAtRoute(nameof(GetCustomer), new { id = customer.Id }, customer);
    }

    return BadRequest();
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Edit(int id, Customer customer)
  {
    if (id != customer.Id)
    {
      return BadRequest($"Customer id conflict");
    }

    if (ModelState.IsValid)
    {
      await _customerService.Update(customer);
      return Ok($"Customer id {id} succesfully updated");
    }

    return NotFound();
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    Customer customer = await _customerService.GetById(id);

    if (customer != null)
    {
      await _customerService.Delete(customer);
      return Ok($"Customer id {id} succesfully deleted");
    }

    return NotFound();
  }
}