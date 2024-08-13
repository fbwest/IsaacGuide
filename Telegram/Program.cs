using Infrastructure;
using Serilog;
using Telegram;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
    
Log.Information("IsaacGuide.Back running at: {Time}", DateTimeOffset.Now);

var context = new AppDbContext();
var contextInitializer = new AppDbContextInitializer(context, Log.Logger);

string? s = default;

var bot = new TgBot();
await bot.RunAsync();

class Test
{
    public string Name { get; set; } = string.Empty;
}