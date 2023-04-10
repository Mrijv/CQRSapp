using System.Threading;
using System.Threading.Tasks;

namespace FinancialRise.DebtManagement.Application.EventConfiguration
{
    public interface IEventHandler<in T>
    {
        ValueTask Handle(T @event, CancellationToken token);
    }
}
