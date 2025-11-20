using MediatR;

namespace Lab10BarredaPintoZoriel.Application.Commands.Response.DeleteResponse;

public sealed record DeleteResponseCommand(Guid Id) : IRequest;