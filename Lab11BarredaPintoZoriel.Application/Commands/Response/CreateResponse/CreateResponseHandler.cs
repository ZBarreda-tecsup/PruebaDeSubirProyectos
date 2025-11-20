using Lab11BarredaPintoZoriel.Domain.Interfaces;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab10BarredaPintoZoriel.Application.Commands.CreateResponse;

public class CreateResponseHandler : IRequestHandler<CreateResponseCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
    {
        var dto = request.ResponseDto;

        if (dto.TicketId == Guid.Empty)
            throw new ApplicationException("Debe asignarse un ticket a la respuesta.");

        if (string.IsNullOrWhiteSpace(dto.Message))
            throw new ApplicationException("El mensaje no puede estar vacío.");

        var ticketExists = await _unitOfWork.Tickets
            .GetAll()
            .AnyAsync(t => t.TicketId == dto.TicketId, cancellationToken);

        if (!ticketExists)
            throw new ApplicationException("El ticket especificado no existe.");

        var response = new Lab11BarredaPintoZoriel.Infrastructure.Models.Response
        {
            ResponseId = Guid.NewGuid(),
            TicketId = dto.TicketId,    
            Message = dto.Message,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Responses.AddAsync(response);
        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}