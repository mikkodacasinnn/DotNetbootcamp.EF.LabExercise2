﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRecruitment.Models
{
    public partial class CandidateSkill
    {
        public string CCandidateCode { get; set; }
        public string CSkillCode { get; set; }

        public virtual ExternalCandidate CCandidateCodeNavigation { get; set; }
        public virtual Skill CSkillCodeNavigation { get; set; }
    }
}
