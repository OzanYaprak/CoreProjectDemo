using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.EntityFramework
{
    public class EFCustomerDAL : GenericRepository<Customer>, ICustomerDAL
    {
        public List<Customer> GetCustomerListIncludeJobs()
        {
            throw new System.NotImplementedException();
        }
    }
}