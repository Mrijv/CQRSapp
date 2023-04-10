using System;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Savings.Commands.CreateSaving;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinancialRise.DebtManagement.Identity.Seed
{
    public static class CreateFirstUser
    {
        public static readonly Guid UserId = Guid.Parse("{69787623-4C52-43FE-B0C9-B7044FB59290}");

        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            var appUser = new ApplicationUser
            {
                Id = UserId,
                UserName = "marianawrocka3",
                Email = "maria3@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(appUser.Email);

            if (user == null)
            {
                CreateSavingCommand command = new CreateSavingCommand() { UserId = UserId, TotalSaving = 0 };
                var savingId = await mediator.Send(command);
                
                if(savingId == Guid.Empty)
                    return;

                await userManager.CreateAsync(appUser, "KaczkaDziwaczka!123");
            }
        }
    }
}
