using EmployeeRecruitment.Data;
using EmployeeRecruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecruitment.Repositories
{
    internal class EmployeeSkillRepository : GenericRepository<EmployeeSkill>, IRepository<EmployeeSkill>
    {
        public EmployeeSkillRepository(RecruitmentContext context) : base(context)
        {
        }
        public IEnumerable<dynamic> FindAll(string employeeCode)
        {
            var skills = this.Context.EmployeeSkills
                .Join(
                Context.Skills,
                es => es.CSkillCode,
                s => s.CSkillCode,
                (es, s) => new
                {
                    CEmployeeCode = es.CEmployeeCode,
                    CSkillCode = s.VSkill
                }
                )
                .Where(x => x.CEmployeeCode == employeeCode)
                .ToList();
            
            return skills;

        }
    }
}
