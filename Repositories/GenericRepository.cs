using EmployeeRecruitment.Data;
using EmployeeRecruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecruitment.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(string id);
    }
    public class GenericRepository<T> where T : class
    {
        public RecruitmentContext Context { get; set; }

        public GenericRepository(RecruitmentContext context)
        {
            this.Context = context;
        }
        public IEnumerable<T> FindAll()
        {
            IQueryable<T> query = this.Context.Set<T>();
            return query.Select(e => e).ToList();
        }

        public T FindById(string id)
        {
            var entity = this.Context.Find<T>(id);
            if (entity != null)
            {
                return entity;
            }
            return null;
        }
    }
}
