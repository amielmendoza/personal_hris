namespace HRIS.Domain.Types
{
    public class EmployeeFilterType
    {
        private EmployeeFilterType(string value) { Value = value; }
        public string Value { get; set; }
        public static EmployeeFilterType EmployeeNo { get { return new EmployeeFilterType("EmployeeNo"); } }
        public static EmployeeFilterType FullName { get { return new EmployeeFilterType("FullName"); } }

        public static EmployeeFilterType BirthDate { get { return new EmployeeFilterType("BirthDate"); } }
        public static EmployeeFilterType HireDate { get { return new EmployeeFilterType("HireDate"); } }
        public static EmployeeFilterType EmploymentStatus { get { return new EmployeeFilterType("EmploymentStatus"); } }
        public static EmployeeFilterType DailyRate { get { return new EmployeeFilterType("DailyRate"); } }
        public static EmployeeFilterType Site { get { return new EmployeeFilterType("Site"); } }
        public static EmployeeFilterType Position { get { return new EmployeeFilterType("Position"); } }
        public static EmployeeFilterType Status { get { return new EmployeeFilterType("Status"); } }
        public static EmployeeFilterType LeaveBalance { get { return new EmployeeFilterType("LeaveBalance"); } }
    }
}
