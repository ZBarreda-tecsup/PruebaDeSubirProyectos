using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;

namespace Lab10BarredaPintoZoriel.Application.Queries.GetAllResponse;

public sealed record GetAllResponsesQuery() : IRequest<IEnumerable<ResponseDTo>>;