using AutoMapper;
using Core.Entities;
using API.Dtos;
using System;

namespace API.Helpers
{
    public class TicketColorResolver : IValueResolver<Ticket, TicketDto, string>
    {
        public string Resolve(Ticket source, TicketDto destination, string destMember, ResolutionContext context)
        {
            /*
            Each ticket will have a color 
            yellow if it was created 15 minutes ago 
            Green  if it was created 30 minutes ago
            Blue   if it was created 45 minutes ago
            Red    if it was created 60 minutes ago
            */

           if( DateTimeOffset.UtcNow >= source.CreationDateTime.AddMinutes(15))
           {
                return "yellow";
           }
           else if( DateTimeOffset.UtcNow >= source.CreationDateTime.AddMinutes(30))
           {
                return "green";
           }
           else if( DateTimeOffset.UtcNow >= source.CreationDateTime.AddMinutes(45))
           {
                return "blue";
           }
           else if( DateTimeOffset.UtcNow >= source.CreationDateTime.AddMinutes(60))
           {
                return "red";
           }
        
            return null;
        }
    }
}