using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Unit11_Homework.Services;

namespace Unit11_Homework.Controllers
{
    public class InlineKeyboardController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;
        public InlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery.Data == null)
                return;
            _memoryStorage.GetSession(callbackQuery.From.Id).Choise = callbackQuery.Data;
            Console.WriteLine($"Пользователь {callbackQuery.From.Id} выбрал {_memoryStorage.GetSession(callbackQuery.From.Id).Choise}");
           // await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Обнаружено нажатие на кнопку {callbackQuery.Data}", cancellationToken: ct);

        }
    }
}
