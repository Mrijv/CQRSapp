using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using FinancialRise.DebtManagement.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialRise.DebtManagement.Persistence
{
    public static class PersistenceServiceRegistration 
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FinancialRiseDbContext>(opt
                => opt.UseSqlServer(configuration.GetConnectionString("FinancialRiseDebtManagementConnectionString")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => { options.ClaimsIdentity.UserIdClaimType = "id"; })
                .AddEntityFrameworkStores<FinancialRiseDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IDebtRepository, DebtRepository>();
            services.AddScoped<IFrequencyRepository, FrequencyRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IOutcomeRepository, OutcomeRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IDailyOperationRepository, DailyOperationRepository>();
            services.AddScoped<ISavingRepository, SavingRepository>();

            return services;
        }
    }
}
