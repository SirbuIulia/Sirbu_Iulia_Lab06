using DataAccess = LibraryModel.Data;
using ModelAccess = LibraryModel.Models;
using Grpc.Core;
using GrpcCustomersService;

public class GrpcCrudService : CustomerService.CustomerServiceBase
{
    private DataAccess.LibraryContext db = null;

    public GrpcCrudService(DataAccess.LibraryContext db)
    {
        this.db = db;
    }

    public override Task<CustomerList> GetAll(Empty empty, ServerCallContext context)
    {
        CustomerList pl = new CustomerList();
        var query = from cust in db.Customers
                    select new Customer()
                    {
                        CustomerId = cust.CustomerID,
                        Name = cust.Name,
                        Adress = cust.Adress,
                        Birthdate = cust.BirthDate.ToString("yyyy-MM-dd")
                    };
        pl.Item.AddRange(query.ToArray());
        return Task.FromResult(pl);
    }

    public override Task<Empty> Insert(Customer requestData, ServerCallContext context)
    {
        db.Customers.Add(new ModelAccess.Customer
        {
            CustomerID = requestData.CustomerId,
            Name = requestData.Name,
            Adress = requestData.Adress,
            BirthDate = DateTime.Parse(requestData.Birthdate)
        });
        db.SaveChanges();
        return Task.FromResult(new Empty());
    }

    public override Task<Customer> Update(Customer requestData, ServerCallContext context)
    {
        var customer = db.Customers.FirstOrDefault(c => c.CustomerID == requestData.CustomerId);
        if (customer != null)
        {
            customer.Name = requestData.Name;
            customer.Adress = requestData.Adress;
            customer.BirthDate = DateTime.Parse(requestData.Birthdate);
            db.SaveChanges();
        }
        return Task.FromResult(requestData);
    }

    public override Task<Empty> Delete(CustomerId requestData, ServerCallContext context)
    {
        var customer = db.Customers.FirstOrDefault(c => c.CustomerID == requestData.Id);
        if (customer != null)
        {
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
        return Task.FromResult(new Empty());
    }
}
