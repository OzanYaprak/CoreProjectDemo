using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EFCustomerDAL : GenericRepository<Customer>, ICustomerDAL
    {
        private SQLContext sqlcontext = new SQLContext();

        public List<Customer> GetCustomerListIncludeJobs()
        {
            return sqlcontext.Customers.Include(x => x.Jop).ToList();
        }
    }
}