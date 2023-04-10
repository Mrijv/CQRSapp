using AutoMapper;
using FinancialRise.DebtManagement.Application.Features.Common;
using FinancialRise.DebtManagement.Application.Features.Contacts.Commands.CreateContact;
using FinancialRise.DebtManagement.Application.Features.Contacts.Commands.UpdateContact;
using FinancialRise.DebtManagement.Application.Features.Contacts.Queries.GetContactsList;
using FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.CreateDailyOperation;
using FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.UpdateDailyOperation;
using FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries;
using FinancialRise.DebtManagement.Application.Features.Debts.Commands.CreateDebt;
using FinancialRise.DebtManagement.Application.Features.Debts.Commands.UpdateDebt;
using FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtsList;
using FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtWithContacts;
using FinancialRise.DebtManagement.Application.Features.Frequencies;
using FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.CreateFrequency;
using FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.UpdateFrequency;
using FinancialRise.DebtManagement.Application.Features.Frequencies.Queries.GetFrequency;
using FinancialRise.DebtManagement.Application.Features.Goals.Commands.CreateGoal;
using FinancialRise.DebtManagement.Application.Features.Goals.Commands.UpdateGoal;
using FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalDetail;
using FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalList;
using FinancialRise.DebtManagement.Application.Features.Incomes.Commands.CreateIncome;
using FinancialRise.DebtManagement.Application.Features.Incomes.Commands.UpdateIncome;
using FinancialRise.DebtManagement.Application.Features.Incomes.Queries.GetIncomesList;
using FinancialRise.DebtManagement.Application.Features.Notes.Commands.CreateNote;
using FinancialRise.DebtManagement.Application.Features.Notes.Commands.UpdateNote;
using FinancialRise.DebtManagement.Application.Features.Notes.Queries;
using FinancialRise.DebtManagement.Application.Features.Notes.Queries.GetNote;
using FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.CreateOutcome;
using FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.UpdateOutcome;
using FinancialRise.DebtManagement.Application.Features.Outcomes.Queries.GetOutcomesList;
using FinancialRise.DebtManagement.Application.Features.Savings.Commands.CreateSaving;
using FinancialRise.DebtManagement.Application.Features.Savings.Commands.UpdateSaving;
using FinancialRise.DebtManagement.Application.Features.Savings.Queries.GetSaving;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Debt, DebtListVm>().ReverseMap();
            CreateMap<Debt, DebtWithContactsVm>().ReverseMap()
                .ForMember(dest=>dest.Contacts, act=>act.MapFrom(src=>src.Contacts));
            CreateMap<Frequency, CreateFrequencyCommand>().ReverseMap();
            CreateMap<Frequency, UpdateFrequencyCommand>().ReverseMap();
            CreateMap<Frequency, FrequencyDto>().ReverseMap();
            CreateMap<Frequency, FrequencyVm>().ReverseMap()
                .ForMember(dest => dest.Unit, act => act.MapFrom(src => src.Unit));
            CreateMap<Contact, ContactDto>().ReverseMap();
                CreateMap<Debt, CreateDebtCommand>().ReverseMap();
            CreateMap<Debt, UpdateDebtCommand>().ReverseMap();
            CreateMap<Goal, GoalListVm>().ReverseMap();
            CreateMap<Goal, GoalDetailVm>().ReverseMap();
            CreateMap<Goal, CreateGoalCommand>().ReverseMap();
            CreateMap<Goal, UpdateGoalCommand>().ReverseMap();
            CreateMap<Income, CreateIncomeCommand>().ReverseMap();
            CreateMap<Income, UpdateIncomeCommand>().ReverseMap();
            CreateMap<Income, IncomesListVm>().ReverseMap()
                .ForMember(dest => dest.Frequency, act => act.MapFrom(src => src.Frequency));
            CreateMap<Outcome, CreateOutcomeCommand>().ReverseMap();
            CreateMap<Outcome, UpdateOutcomeCommand>().ReverseMap();
            CreateMap<Outcome, OutcomesListVm>().ReverseMap()
                .ForMember(dest => dest.Frequency, act => act.MapFrom(src => src.Frequency));
            CreateMap<Outcome, OutcomeDto>().ReverseMap()
                .ForMember(dest => dest.Frequency, act => act.MapFrom(src => src.Frequency));
            CreateMap<UnitOfFrequency, UnitOfFrequencyDtoType>().ReverseMap();
            CreateMap<Contact, ContactListVm>().ReverseMap();
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Note, UpdateNoteCommand>().ReverseMap();
            CreateMap<Note, CreateNoteCommand>().ReverseMap();
            CreateMap<Note, NoteVm>().ReverseMap();
            CreateMap<DailyOperation, CreateDailyOperationCommand>().ReverseMap();
            CreateMap<DailyOperation, UpdateDailyOperationCommand>().ReverseMap();
            CreateMap<DailyOperation, DailyOperationVm>().ReverseMap();
            CreateMap<Saving, SavingVm>().ReverseMap();
            CreateMap<Saving, CreateSavingCommand>().ReverseMap();
            CreateMap<Saving, UpdateSavingCommand>().ReverseMap();
        }
    }
}
