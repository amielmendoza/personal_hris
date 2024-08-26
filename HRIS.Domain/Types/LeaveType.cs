namespace HRIS.Domain.Types
{
    public class LeaveType
    {
        private LeaveType (string value) { Value = value; }
        public string Value { get; set; }
        public static LeaveType Vacation { get { return new LeaveType("Vacation"); } }
        public static LeaveType Sick { get { return new LeaveType("Sick"); } }
        public static LeaveType Emergency { get { return new LeaveType("Emergency"); } }
        public static LeaveType Maternity { get { return new LeaveType("Maternity"); } }
        public static LeaveType Paternity { get { return new LeaveType("Paternity"); } }
        public static LeaveType Unpaid { get { return new LeaveType("Unpaid"); } }
    }
}
