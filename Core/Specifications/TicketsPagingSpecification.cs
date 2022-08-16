using System;
using Core.Entities;

namespace Core.Specifications
{
    public class TicketsPagingSpecification : BaseSpecification<Ticket>
    {
        public TicketsPagingSpecification(TicketSpecParams ticketParams)       
        {
            ApplyPaging(ticketParams.PageSize * (ticketParams.PageIndex - 1), ticketParams.PageSize);
        }

    }
}