using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;

namespace Lab10BarredaPintoZoriel.Application.Commands.CreateTicket;


public sealed record CreateTicketCommand(TicketCreateDTo TicketDto) : IRequest<Unit>;