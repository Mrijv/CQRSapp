using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;
using FinancialRise.DebtManagement.Persistence.SeedingData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinancialRise.DebtManagement.Persistence
{
    public class FinancialRiseDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public FinancialRiseDbContext(DbContextOptions<FinancialRiseDbContext> options)
            : base(options)
        {
        }

        public FinancialRiseDbContext(DbContextOptions<FinancialRiseDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<DailyOperation> DailyOperations { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancialRiseDbContext).Assembly);

            modelBuilder.Entity<Saving>()
                .Property(o => o.TotalSaving)
                .HasColumnType("money");

            modelBuilder.Entity<Debt>()
                .Property(o => o.Instalment)
                .HasColumnType("money");
            
            modelBuilder.Entity<Debt>()
                .Property(o => o.LoanAmount)
                .HasColumnType("money");

            modelBuilder.Entity<Debt>()
                .Property(o => o.Total)
                .HasColumnType("money");

            modelBuilder.Entity<DailyOperation>()
                .Property(o => o.Amount)
                .HasColumnType("money");

            modelBuilder.Entity<Goal>()
                .Property(o => o.Amount)
                .HasColumnType("money");

            modelBuilder.Entity<Income>()
                .Property(o => o.Amount)
                .HasColumnType("money");

            modelBuilder.Entity<Outcome>()
                .Property(o => o.Amount)
                .HasColumnType("money");

            //modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            //{
            //    ContactId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
            //    UserName = "marianawrocka",
            //    Email = "maria@test.com",
            //    EmailConfirmed = true
            //});

            foreach (var frequency in SeedFrequencies.GetFrequencies())
            {
                modelBuilder.Entity<Frequency>().HasData(frequency);
            }

            foreach (var debt in SeedDebts.GetDebts())
            {
                modelBuilder.Entity<Debt>().HasData(debt);
            }

            foreach (var contact in SeedContacts.GetContacts())
            {
                modelBuilder.Entity<Contact>().HasData(contact);
            }

            foreach (var dailyOperation in SeedDailyOperations.GetDailyOperations())
            {
                modelBuilder.Entity<DailyOperation>().HasData(dailyOperation);
            }

            foreach (var goal in SeedGoals.GetGoals())
            {
                modelBuilder.Entity<Goal>().HasData(goal);
            }

            foreach (var income in SeedIncomes.GetIncomes())
            {
                modelBuilder.Entity<Income>().HasData(income);
            }

            foreach (var note in SeedNotes.GetNotes())
            {
                modelBuilder.Entity<Note>().HasData(note);
            }

            foreach (var outcome in SeedOutcomes.GetOutcomes())
            {
                modelBuilder.Entity<Outcome>().HasData(outcome);
            }

            modelBuilder.Entity<Saving>().HasData(new Saving()
            {
                SavingId = Guid.Parse("7EF244DE-A44F-4F08-91FB-7C0445EA7802"),
                UserId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                TotalSaving = 0,
                CreatedBy = "SeedingData",
                CreatedDate = DateTime.Now
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
