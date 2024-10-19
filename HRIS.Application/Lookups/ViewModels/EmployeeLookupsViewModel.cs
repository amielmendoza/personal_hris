using HRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Lookups.ViewModels
{
    public class EmployeeLookupsViewModel
    {
        public List<ReferenceEntity> ContractEndReasons { get; set; }
        public List<ReferenceEntity> Departments { get; set; }
        public List<ReferenceEntity> EmployeeLeaveStatuses { get; set; }
        public List<ReferenceEntity> EmployeeLeaveTypes { get; set; }
        public List<ReferenceEntity> EmployeeLoanStatuses { get; set; }
        public List<ReferenceEntity> EmployeeLoanTypes { get; set; }
        public List<ReferenceEntity> EmployeeStatuses { get; set; }
        public List<ReferenceEntity> Sites { get; set; }
    }
}
