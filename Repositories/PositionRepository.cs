using EmployeeRecruitment.Data;
using EmployeeRecruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecruitment.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IRepository<Position>
    {
        public PositionRepository(RecruitmentContext context) : base(context)
        {
        }
    }
}
