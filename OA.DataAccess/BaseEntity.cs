using System;

namespace OA.DataAccess
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
