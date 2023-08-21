using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : IGenericService<Category>
    {
        ICategoryDAL _CategoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _CategoryDAL = categoryDAL;
        }

        public void Add(Category t)
        {
            _CategoryDAL.Add(t);
        }

        public void Delete(Category t)
        {
            _CategoryDAL.Delete(t);
        }

        public List<Category> GetAll()
        {
            return _CategoryDAL.GetAll();
        }

        public Category GetByID(int id)
        {
            return _CategoryDAL.GetByID(id);
        }

        public void Update(Category t)
        {
            _CategoryDAL.Update(t);
        }
    }
}
