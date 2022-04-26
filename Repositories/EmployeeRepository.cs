using EmployeeRecruitment.Data;
using EmployeeRecruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecruitment.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IRepository<Employee>
    {
        public EmployeeRepository(RecruitmentContext context) : base(context)
        {

        }
    }
}
