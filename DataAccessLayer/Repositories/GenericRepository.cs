using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        private SQLContext sqlcontext = new SQLContext();

        public void Add(T t)
        {
            sqlcontext.Add(t);
            sqlcontext.SaveChanges();
        }

        public void Delete(T t)
        {
            sqlcontext.Remove(t);
            sqlcontext.SaveChanges();
        }

        public T GetByID(int id)
        {
            return sqlcontext.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return sqlcontext.Set<T>().ToList();
        }

        public void Update(T t)
        {
            sqlcontext.Update(t);
            sqlcontext.SaveChanges();
        }
    }
}