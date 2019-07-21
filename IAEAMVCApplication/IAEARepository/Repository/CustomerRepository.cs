using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using IAEARepository.Interface;
using IAEADataModel;

namespace IAEARepository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private IAEADatabaseEntities context;

        public CustomerRepository(IAEADatabaseEntities context)
        {
            this.context = context;
        }

        public IList<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public Customer GetCustomerByID(int customerId)
        {
            return context.Customers.Single(b => b.ID == customerId);
        }

        public void InsertCustomer(Customer customer)
        {
            context.Customers.AddObject(customer);
            context.SaveChanges();            
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = context.Customers.Single(b => b.ID == customerId);
            context.Customers.DeleteObject(customer);
            context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            context.Customers.Attach(customer);
            context.ObjectStateManager.ChangeObjectState(customer, EntityState.Modified);
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}