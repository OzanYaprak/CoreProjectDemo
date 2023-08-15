using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {
        void Add(T t);

        void Delete(T t);

        void Update(T t);

        List<T> GetAll();

        T GetByID(int id);
    }
}