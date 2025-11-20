using Lab11BarredaPintoZoriel.Application.DTos;
using Lab11BarredaPintoZoriel.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab11BarredaPintoZoriel.Application.Queries.GetAllTickets;

public class GetAllTicketsHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<TicketDTo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTicketsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TicketDTo>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Tickets.GetAll();

        var tickets = await query
            .Include(t => t.User)
            .Include(t => t.Responses)
            .Select(t => new TicketDTo
            {
                user = new UserSimpleDTo
                {
                    UserName = t.User.Username,
                    Email = t.User.Email
                },
                Title = t.Title,
                Description = t.Description,
                ResponseTicketDTo = t.Responses
                    .Select(r => new ResponsesTicketDTo
                    {
                        mesage = r.Message
                    })
                    .FirstOrDefault() ?? new ResponsesTicketDTo { mesage = "" }
            })
            .ToListAsync(cancellationToken);

        return tickets;
    }
}