using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryService _categoryService;

        public CategoryManager(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void Add(Category t)
        {
            _categoryService.Add(t);
        }

        public void Delete(Category t)
        {
            _categoryService.Delete(t);
        }

        public List<Category> GetAll()
        {
            return _categoryService.GetAll();
        }

        public Category GetByID(int id)
        {
            return _categoryService.GetByID(id);
        }

        public void Update(Category t)
        {
            _categoryService.Update(t);
        }
    }
}
