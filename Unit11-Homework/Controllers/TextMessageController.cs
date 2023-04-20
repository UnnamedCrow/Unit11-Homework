using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Unit11_Homework.Services;

namespace Unit11_Homework.Controllers
{
    public class TextMessageController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;
        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кноки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Длина" , $"length"),
                        InlineKeyboardButton.WithCallbackData($" Сумма" , $"sum")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Этот бот может подсчитать длину сообщения.</b> {Environment.NewLine}" +
                        $"{Environment.NewLine}Или найти сумму чисел в строке написанных через пробел.{Environment.NewLine}", cancellationToken: ct, parseMode:
                        ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                default:
                    switch (_memoryStorage.GetSession(message.Chat.Id).Choise)
                    {
                        case "length":
                            // Вывод ответного сообщения с количеством символов
                            await _telegramClient.SendTextMessageAsync(message.Chat.Id,$"Длина Вашего сообщения: {new Length(message.Text).GetLength()}" , cancellationToken: ct);
                            Console.WriteLine($"Вычисление длины сообщения для пользователя {message.Chat.Id}");
                            break;
                        case "sum":
                            Console.WriteLine($"Вычисление суммы пользователя {message.Chat.Id}");
                            break;
                    }
                    break;
            }

          //  Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
           // await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено текстовое сообщение {message.Text}", cancellationToken: ct);
        }
    }
}
