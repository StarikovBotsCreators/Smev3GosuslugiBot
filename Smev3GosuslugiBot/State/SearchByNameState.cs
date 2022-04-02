﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev3GosuslugiBot.State
{
    public class SearchByNameState : IState
    {
        public async Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(update.GetChat(), "Поиск по параметрам");
            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new[]
            {
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Привет"),
                },
                
                new List<KeyboardButton>()
                {
                    new KeyboardButton("123"),
                },
            })
            {
                ResizeKeyboard = true,
                Selective = true,
            };

            await botClient.SendTextMessageAsync(update.GetChat(), "выфвфыв", replyMarkup: keyboard, cancellationToken: cancellationToken);

        }

        public Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}