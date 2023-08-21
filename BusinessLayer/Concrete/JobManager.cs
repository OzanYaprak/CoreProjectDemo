using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class JobManager : IGenericService<Job>
    {
        IJobDAL _jobDAL;

        public JobManager(IJobDAL jobDAL)
        {
            _jobDAL = jobDAL;
        }

        public void Add(Job t)
        {
            _jobDAL.Add(t);
        }

        public void Delete(Job t)
        {
            _jobDAL.Delete(t);
        }

        public List<Job> GetAll()
        {
            return _jobDAL.GetAll();
        }

        public Job GetByID(int id)
        {
            return _jobDAL.GetByID(id);
        }

        public void Update(Job t)
        {
            _jobDAL.Update(t);
        }
    }
}
