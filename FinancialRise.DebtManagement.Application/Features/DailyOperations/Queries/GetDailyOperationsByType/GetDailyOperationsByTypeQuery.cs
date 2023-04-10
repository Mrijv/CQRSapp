using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Common;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries.GetDailyOperationsByType
{
    public class GetDailyOperationsByTypeQuery : IRequest<List<DailyOperationVm>>
    {
        public TypeOfOperation Operation { get; set; }
        public Guid UserId { get; set; }
    }
}
