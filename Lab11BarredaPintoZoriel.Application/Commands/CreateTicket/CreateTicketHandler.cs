using Lab11BarredaPintoZoriel.Domain.Interfaces;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab10BarredaPintoZoriel.Application.Commands.CreateTicket;

public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var dto = request.TicketDto;

        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ApplicationException("El título no puede estar vacío.");

        if (dto.UserId == Guid.Empty)
            throw new ApplicationException("Debe asignarse un usuario al ticket.");

        var userExists = await _unitOfWork.Users
            .GetAll()
            .AnyAsync(u => u.UserId == dto.UserId, cancellationToken);

        if (!userExists)
            throw new ApplicationException("El usuario asignado no existe.");

        var newTicket = new Ticket
        {
            TicketId = dto.Id != Guid.Empty ? dto.Id : Guid.NewGuid(),
            UserId = dto.UserId,
            Title = dto.Title,
            Description = dto.Description,
            Status = dto.status ?? "abierto",
            CreatedAt = dto.CreateAt ?? DateTime.UtcNow,
            ClosedAt = dto.CloseAt
        };

        await _unitOfWork.Tickets.AddAsync(newTicket);
        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}