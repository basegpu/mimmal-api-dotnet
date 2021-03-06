using TestApi.Models;

namespace TestApi.Repositories;

class CustomerRepository : ICustomerRepository
{
	private readonly Dictionary<Guid, Customer> _customers = new();

	public Guid Add(string fullname)
	{
		var customer = new Customer(Guid.NewGuid(), fullname);
		_customers[customer.Id] = customer;
		return customer.Id;
	}

	public Customer GetById(Guid id)
	{
		return _customers[id];
	}

	public List<Customer> GetAll()
	{
		return _customers.Values.ToList();
	}

	public bool TryUpdate(Guid id, string fullname)
	{
		var existingCustomer = GetById(id);
		if (existingCustomer is null) return false;
		_customers[id] = new Customer(id, fullname);
		return true;
	}

	public bool TryDelete(Guid id)
	{
		if (!_customers.Keys.Contains(id)) return false;
		_customers.Remove(id);
		return true;
	}
}