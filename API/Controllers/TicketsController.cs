using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TicketsController : BaseApiController
    {
        private readonly IGenericRepository<Ticket> _repoTicket;
        public TicketsController(IGenericRepository<Ticket> repoTicket)
        {
            _repoTicket = repoTicket;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<TicketDto>>> GetTickets([FromQuery] TicketSpecParams ticketParams)
        {
            var totalCount = await _repoTicket.CountAsync();

            var spec = new TicketsPagingSpecification(ticketParams);
            var tickets = await _repoTicket.ListAsync(spec);

            var data = Mapper.Map<IReadOnlyList<TicketDto>>(tickets);

            return Ok(new Pagination<TicketDto>(ticketParams.PageIndex, ticketParams.PageSize, totalCount, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TicketDto>> GetTicket(int id)
        {
            var ticket = await _repoTicket.GetByIdAsync(id);
            if (ticket == null) return NotFound(new ApiResponse(404));
            return Ok(Mapper.Map<TicketDto>(ticket));
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> CreateTicket(TicketDto newTicket)
        {

            var ticket = Mapper.Map<TicketDto, Ticket>(newTicket);

            var result = await _repoTicket.Add(ticket);

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem creating ticket"));

            return Mapper.Map<Ticket, TicketDto>(ticket);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TicketDto>> UpdateTicket(int id, TicketDto ticketToUpdate)
        {
            var ticket = await _repoTicket.GetByIdAsync(id);

            if (ticket == null) return NotFound(new ApiResponse(404));

            Mapper.Map(ticketToUpdate, ticket);

            var result = await _repoTicket.Update(ticket);

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem updating ticket"));

            return Mapper.Map<Ticket, TicketDto>(ticket);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTicket(int id)
        {
            var ticket = await _repoTicket.GetByIdAsync(id);

            if (ticket == null) return NotFound(new ApiResponse(404));
          
            var result = await _repoTicket.Delete(ticket);

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem deleting ticket"));
            
            return Ok(id.ToString());
        }

    }
}