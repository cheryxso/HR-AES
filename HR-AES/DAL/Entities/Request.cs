using System;

namespace DAL.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
        public RequestType RequestType { get; set; }  
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public RequestStatus Status { get; set; }  
    }

    public enum RequestType
    {
        Dismissal,
        Hiring
    }

    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}

