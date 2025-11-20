using Lab11BarredaPintoZoriel.Application.DTos;
using Lab11BarredaPintoZoriel.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab10BarredaPintoZoriel.Application.Queries.GetAllResponse;

public class GetAllResponsesHandler : IRequestHandler<GetAllResponsesQuery, IEnumerable<ResponseDTo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllResponsesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ResponseDTo>> Handle(GetAllResponsesQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Responses.GetAll();

        var responses = await query
            .Include(r => r.Ticket)
            .Select(r => new ResponseDTo
            {
                TicketData = new TicketResponseDTo
                {
                    title = r.Ticket.Title,
                    description = r.Ticket.Description,
                    status = r.Ticket.Status,
                },
                UserData = new UserResponseDTo
                {
                    UserName = r.Ticket.User.Username,
                    Email = r.Ticket.User.Email
                },
                Message = r.Message
            })
            .ToListAsync(cancellationToken);

        return responses;
    }
}