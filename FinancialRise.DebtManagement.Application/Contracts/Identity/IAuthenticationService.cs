using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Models.Authentication;

namespace FinancialRise.DebtManagement.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
