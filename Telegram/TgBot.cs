using CherryBot;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telegram;

public class TgBot
{
    private Chat _botChat = null!;
    
    public async Task RunAsync()
    {
        using var cts = new CancellationTokenSource();
        
        var bot = new TelegramBotClient("7247531326:AAEkVAG7VB2X6bo0hu4-PoNOlL20V0iClDk", cancellationToken: cts.Token);

        await bot.DropPendingUpdatesAsync(cts.Token);
        
        bot.StartReceiving(HandleUpdate, HandleError, null, cts.Token);

        var me = await bot.GetMeAsync(cts.Token);
        Log.Information("@{MeUsername} is running... Press Enter to terminate", me.Username);
        Console.ReadLine();
        await cts.CancelAsync(); // stop the bot
    }
    
    private async Task HandleUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        if (update.Message?.Text is null) return; // we want only updates about new Text Message
        var msg = update.Message;

        _botChat = msg.Chat;
        
        Log.Information("Received message \'{MsgText}\' from {FromFirstName}",
            msg.Text, msg.From?.Username ?? msg.From?.FirstName);
        
        var isDecentCommand = Enum.TryParse<Command>(msg.Text.Split('/').Last(), true, out var command);
        if (!isDecentCommand) throw new Exception("Wrong command");

        var respond = command switch
        {
            Command.Start => "Добро пожаловать в IsaacGuide\ud83d\ude2d!",
            Command.Arts => "Артефакты",
            _ => throw new Exception("Wrong command")
        };
        
        await bot.SendTextMessageAsync(msg.Chat, respond, cancellationToken: ct);
    }
    
    private async Task HandleError(ITelegramBotClient bot, Exception ex, CancellationToken ct)
    {
        Log.Error("{Message}", ex.Message);

        await bot.SendTextMessageAsync(_botChat, ex.Message, cancellationToken: ct);
    }
}