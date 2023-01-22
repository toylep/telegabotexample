// See https://aka.ms/new-console-template for more information
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

internal class Program
{
   private static ITelegramBotClient bot;
    private static string token { get; set; } = "5878539084:AAGTLi_RIuPYsFpesxhT2ZdcyCmuxjU0eGg";
    
    
    private static void Main(string[] args)
    {
        bot = new TelegramBotClient(token);
        bot.OnMessage += OnMessageHandler;
      /*  Console.WriteLine("Bot started "+ bot.GetMeAsync().Result.FirstName);
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { },
        };

        var me = bot.GetMeAsync();
        Console.WriteLine($"HEllo my name is {me}");
        Console.ReadLine();
      */

    }
    private static void OnMessageHandler(object sender, MessageEventArgs e)
}