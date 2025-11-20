using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;

namespace Lab11BarredaPintoZoriel.Application.Queries.GetAllTickets;

public sealed record GetAllTicketsQuery() : IRequest<IEnumerable<TicketDTo>>;