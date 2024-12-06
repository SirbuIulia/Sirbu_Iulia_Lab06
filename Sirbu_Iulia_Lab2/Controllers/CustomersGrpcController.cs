using Grpc.Net.Client;
using GrpcCustomersService;
using LibraryModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Nume_Pren_Lab2.Controllers
{
    public class CustomersGrpcController : Controller
    {
        private readonly GrpcChannel channel;

        public CustomersGrpcController()
        {
            channel = GrpcChannel.ForAddress("https://localhost:5001");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            CustomerList cust = client.GetAll(new Empty());
            return View(cust);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new CustomerService.CustomerServiceClient(channel);
                var createdCustomer = client.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            var customer = client.Get(new CustomerId { Id = id });
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new CustomerService.CustomerServiceClient(channel);
                var updatedCustomer = client.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            var customer = client.Get(new CustomerId { Id = id });
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            client.Delete(new CustomerId { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
