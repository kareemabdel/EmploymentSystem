using Contracts;
using EmploymentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Services
{
    public class VacancyService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILoggerManager _loggerManager;

        public VacancyService(IApplicationDbContext context, ILoggerManager loggerManager)
        {
            _context = context;
            _loggerManager = loggerManager;
        }

        public async Task ArchiveExpiredVacancies()
        {
            try
            {
                var expiredVacancies = _context.Vaccancies
               .Where(v => v.ExpiredDate <= DateTime.Now && v.Status != Domain.Enums.VaccancyStatusEnum.Archived)
               .ToList();

                foreach (var vacancy in expiredVacancies)
                {
                    vacancy.Status = Domain.Enums.VaccancyStatusEnum.Archived;
                }

                await _context.SaveChangesAsync(new CancellationToken());
            }
            catch (Exception ex)
            {

                _loggerManager.LogError($"VacancyService Went Wrong: {ex.Message}");
            }
           
        }
    }
}
