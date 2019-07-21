using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAEADataModel;

namespace IAEARepository.Interface
{
    public interface ICustomerRepository : IDisposable
    {
        IList<Customer> GetCustomers();
        Customer GetCustomerByID(int customerId);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
    }
}
