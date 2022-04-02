using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev3GosuslugiBot.State.SearchByParameters
{
    public class ContextOfUseState : IState
    {
        private readonly IMessageReceiver _messageReceiver;

        public ContextOfUseState(IMessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
        }
    
        public async Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new[]
            {
                new List<KeyboardButton> { new KeyboardButton("Межведомственное взаимодействие") },
                new List<KeyboardButton> { new KeyboardButton("Межведомственное взаимодействие/Базовый реестр") },
                new List<KeyboardButton> { new KeyboardButton("Приём заявлений с ЕПГУ") },
                new List<KeyboardButton> { new KeyboardButton("Прием заявлений с ЕПГУ/МФЦ") },
            }) 
            {
                ResizeKeyboard = true,
                Selective = true
            };

            await botClient.SendTextMessageAsync(update.GetChat(), "Выберите область применения", replyMarkup: keyboard,
                cancellationToken: cancellationToken);
        }

        public Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}