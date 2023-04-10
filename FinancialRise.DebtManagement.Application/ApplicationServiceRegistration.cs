using System.Reflection;
using FinancialRise.DebtManagement.Application.Contracts.Services;
using FinancialRise.DebtManagement.Application.Features.Debts.Services;
using FinancialRise.DebtManagement.Application.Features.Summary.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialRise.DebtManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ICalculateDebt, CalculateDebt>();
            services.AddTransient<ICalculateGoal, CalculateGoal>();
            services.AddTransient<ITurnoverCalculationHelper, TurnoverCalculationHelper>();

            return services;
        }
    }
}
