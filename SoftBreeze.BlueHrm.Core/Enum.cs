namespace SoftBreeze.BlueHrm
{ 
    public enum Gender
    {
        Male = 1, Female = 0
    }

    public enum MarritalStatus { Single = 0, Married = 1}

    public enum RelationshipType
    {
        Child = 0, Others =1
    }

    public enum ImmigrationDocument
    {
        Passport = 0, Visa = 1
    }

    public enum EmployeeReportMethod
    {
        Direct = 0, Inderect = 1, Others = 2
    }

    public enum EmployeeStatus
    {
        Active = 0, Suspended = 1, JobTerminated = 2
    }

    public enum MembershipSuscriptionPayer { Individual = 0, Company = 1}

    public enum LeaveRequestStatus
    {
        Pending = 1, Approved = 2, Rejected = 3, All = 0
    }
    public enum LeaveStatus
    {
        All = 0, PendingApproval = 1, Approved = 2, Scheduled = 3, Taken = 4, Canceled = 5
    }

    public enum AttendanceStatus
    {
        Present = 0,
        Absent = 1,
        Sick = 2,
        Travelled = 3,
        Leave = 4,
        OnCourse = 5
    }

    public enum PerformanceEvaluationStatus
    {
        NotStarted = 0, Started = 1, Completed = 2
    }
}
