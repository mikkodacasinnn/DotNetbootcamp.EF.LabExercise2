using EmployeeRecruitment.Data;
using EmployeeRecruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecruitment.Repositories
{
    public class AnnualSalaryRepository : GenericRepository<AnnualSalary>, IRepository<AnnualSalary>
    {
        public AnnualSalaryRepository(RecruitmentContext context) : base(context)
        {
        }
        public IEnumerable<AnnualSalary> FindAll(string employeeCode)
        {
            return this.Context.AnnualSalaries.Where(x => x.CEmployeeCode.Equals(employeeCode)).ToList();
        }
    }
}
