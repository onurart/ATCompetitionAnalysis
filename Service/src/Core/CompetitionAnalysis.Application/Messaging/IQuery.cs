using MediatR;

namespace CompetitionAnalysis.Application.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
