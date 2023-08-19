using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService : IGenericService<Customer>
    {
        List<Customer> GetCustomerListIncludeJobs();
    }
}