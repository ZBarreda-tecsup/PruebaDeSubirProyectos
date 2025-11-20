using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;

namespace Lab10BarredaPintoZoriel.Application.Commands.CreateResponse;

public sealed record CreateResponseCommand(ResponseCreateDTo ResponseDto) : IRequest<Unit>;