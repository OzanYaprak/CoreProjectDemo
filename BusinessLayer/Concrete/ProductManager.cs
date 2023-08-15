using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void Add(Product t)
        {
            _productDAL.Add(t);
        }

        public void Delete(Product t)
        {
            _productDAL.Delete(t);
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetAll();
        }

        public Product GetByID(int id)
        {
            return _productDAL.GetByID(id);
        }

        public void Update(Product t)
        {
            _productDAL.Update(t);
        }
    }
}
