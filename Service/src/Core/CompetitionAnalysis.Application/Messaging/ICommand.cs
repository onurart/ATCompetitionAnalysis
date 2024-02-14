using MediatR;

namespace CompetitionAnalysis.Application.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
