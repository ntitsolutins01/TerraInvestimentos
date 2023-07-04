using TerraInvestimentos.Application.Common.Interfaces;

namespace TerraInvestimentos.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
