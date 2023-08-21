using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : IGenericService<Customer>
    {
        private ICustomerDAL _customerDAL;

        public CustomerManager(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        public void Add(Customer t)
        {
            _customerDAL.Add(t);
        }

        public void Delete(Customer t)
        {
            _customerDAL.Delete(t);
        }

        public List<Customer> GetAll()
        {
            return _customerDAL.GetAll();
        }

        public Customer GetByID(int id)
        {
            return _customerDAL.GetByID(id);
        }

        public List<Customer> GetCustomerListIncludeJobs()
        {
            return _customerDAL.GetCustomerListIncludeJobs();
        }

        public void Update(Customer t)
        {
            _customerDAL.Update(t);
        }
    }
}