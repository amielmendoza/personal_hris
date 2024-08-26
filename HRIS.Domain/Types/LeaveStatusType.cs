namespace HRIS.Domain.Types
{
    public class LeaveStatusType
    {
        private LeaveStatusType (string value) { Value = value;  }
        public string Value { get; set; }
        public static LeaveStatusType New { get { return new LeaveStatusType("New"); } }
        public static LeaveStatusType Approved { get { return new LeaveStatusType("Approved"); } }
        public static LeaveStatusType Denied { get { return new LeaveStatusType("Denied"); } }
    }
}
