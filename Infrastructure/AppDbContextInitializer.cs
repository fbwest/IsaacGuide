using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContextInitializer
{
    private readonly AppDbContext _context;
    private readonly Serilog.ILogger _logger;

    public AppDbContextInitializer(AppDbContext context, Serilog.ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        try
        {
            _logger.Information("Запуск миграций базы данных...");
            await _context.Database.MigrateAsync();
        }
        catch (Exception e)
        {
            _logger.Error(e, "Произошла ошибка инициализации базы данных");
            throw;
        }
    }
}