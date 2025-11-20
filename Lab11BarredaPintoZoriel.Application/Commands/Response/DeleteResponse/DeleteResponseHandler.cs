using Lab11BarredaPintoZoriel.Domain.Interfaces;
using MediatR;

namespace Lab10BarredaPintoZoriel.Application.Commands.Response.DeleteResponse;

public class DeleteResponseHandler : IRequestHandler<DeleteResponseCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task Handle(DeleteResponseCommand request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.Responses.GetById(request.Id);

        if (response == null)
        {
            throw new KeyNotFoundException($"Response with id {request.Id} not found");
        }
        
        _unitOfWork.Responses.Delete(response);
        await _unitOfWork.CompleteAsync();
        
    }
}