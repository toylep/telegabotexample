// See https://aka.ms/new-console-template for more information
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

internal class Program
{
    private static ITelegramBotClient bot;
    private static string token { get; set; } = "5878539084:AAGTLi_RIuPYsFpesxhT2ZdcyCmuxjU0eGg";
    private static string msg;
   // private static List<long> chatIDs= new List<long>();
    private static string namefile = "C:\\Users\\Тюлень\\source\\repos\\telegabotexample\\source\\ChatID.txt";
    private static string[] ids = System.IO.File.ReadAllLines(namefile);
    private static Boolean correct=false;
    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
        {
        Console.WriteLine($"{update.Message.From.FirstName} | {update.Message.From.Username} | {update.Message.From.Id} | {update.Message.Text}");
            for(int i=0;i<ids.Length-1;i++)
            {
               if (ids[i] ==update.Message.From.Id.ToString()) correct=false;
                else
                    correct= true;  
                
            }
            if (correct)
                    System.IO.File.AppendAllText(namefile, update.Message.From.Id.ToString() + "\n");
         /*   var message = update.Message;
            msg = message.Text;
            if (message.Text.ToLower() == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat, "Дарова,выбери список команд\n 1)мои контакты -/author \n 2)Узнать своё имя - /myname \n 3)Персональное сообщение -/personal");
            }
            switch (message.Text.ToLower())
            {
                case ("/author"):
                    await botClient.SendTextMessageAsync(message.Chat, "inst: toylep");
                    break;
                case ("/myname"):
                    await botClient.SendTextMessageAsync(message.Chat, $"{message.From.FirstName}я тебя запомнил");
                    if (message.From.Username == "akemi_lennoks")
                        await botClient.SendTextMessageAsync(message.Chat, "Люблю тебя <3");
                    if (message.From.Username == "dhskizb")
                        await botClient.SendTextMessageAsync(message.Chat, "Хуле в тачке намусорил?");
                    break;
                case ("/personal"):
                    while(message.Text!="Маланова")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "ты пидор");
                    }
                    break;
                case ("/lottery"): 
                    
                    break;
            }
         */
        }
    }

    public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        // Некоторые действия
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
    }

    private static void Main(string[] args)
    {
        bot = new TelegramBotClient(token);
        Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
        //Update update = new Update();
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }, // receive all update types
        };
        bot.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            cancellationToken
        );
        while (true)

        {
            Console.WriteLine("Менюшка: \n 1)-написать всем \n 2)-написать кому-то лично");
            int count = int.Parse(Console.ReadLine());
            switch (count) {
                case 1:
                    Console.WriteLine("Введите сообщение");
            var say = Console.ReadLine();
            foreach (var str in ids)
            {
                bot.SendTextMessageAsync(str, say);
            }
            break;
                    case 2: 
                    Console.WriteLine("Введите сообщение ");
                    var say1 = Console.ReadLine();
                    Console.WriteLine("Введите номер в списке ");
                    bot.SendTextMessageAsync( ids[int.Parse(Console.ReadLine())-1] , say1);
                    break;

           
        }
                        }
        Console.ReadLine();

        

    }


}


