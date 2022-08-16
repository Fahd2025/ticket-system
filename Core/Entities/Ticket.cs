using System;

namespace Core.Entities
{
    public class Ticket : BaseEntity
    {  
        public DateTimeOffset CreationDateTime{ get; set; } = DateTimeOffset.Now;
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }

    }
}