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
    public class JopManager : IJopService
    {
        IJopDAL _jopDAL;

        public JopManager(IJopDAL jopDAL)
        {
            _jopDAL = jopDAL;
        }

        public void Add(Jop t)
        {
            _jopDAL.Add(t);
        }

        public void Delete(Jop t)
        {
            _jopDAL.Delete(t);
        }

        public List<Jop> GetAll()
        {
            return _jopDAL.GetAll();
        }

        public Jop GetByID(int id)
        {
            return _jopDAL.GetByID(id);
        }

        public void Update(Jop t)
        {
            _jopDAL.Update(t);
        }
    }
}
