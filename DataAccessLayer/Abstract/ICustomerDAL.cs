using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface ICustomerDAL : IGenericDAL<Customer>
    {
        List<Customer> GetCustomerListIncludeJobs();
    }
}