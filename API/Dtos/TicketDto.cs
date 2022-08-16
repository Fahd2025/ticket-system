using System;

namespace API.Dtos
{
    public class TicketDto    
    {
        public int Id { get; set; }
        public DateTimeOffset CreationDateTime{ get; set; } = DateTimeOffset.Now;
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Color { get; set; }
    }
}