﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRecruitment.Models
{
    public partial class ContractRecruiter
    {
        public ContractRecruiter()
        {
            ExternalCandidates = new HashSet<ExternalCandidate>();
        }

        public string CContractRecruiterCode { get; set; }
        public string CName { get; set; }
        public string VAddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CZip { get; set; }
        public string CFax { get; set; }
        public string CPhone { get; set; }
        public short? SiPercentageCharge { get; set; }
        public decimal? MTotalPaid { get; set; }

        public virtual ICollection<ExternalCandidate> ExternalCandidates { get; set; }
    }
}
