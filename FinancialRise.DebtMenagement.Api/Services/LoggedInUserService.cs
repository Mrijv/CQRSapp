using System.Security.Claims;
using FinancialRise.DebtManagement.Application.Contracts;
using Microsoft.AspNetCore.Http;

namespace FinancialRise.DebtMenagement.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public string UserId { get; }

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
