﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.State.SearchByParameters;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev3GosuslugiBot.State
{
    public class HelloState : IState
    {
        private const string SearchByName = "Поиск по имени";
        private const string SearchByParameters = "Поиск по параметрам";
        private readonly IMessageReceiver _messageReceiver;

        public HelloState(IMessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
        }

        public async Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(update.GetChat(), SearchByParameters);
            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new[]
            {
                new List<KeyboardButton>()
                {
                    new KeyboardButton(SearchByName),
                },
                
                new List<KeyboardButton>()
                {
                    new KeyboardButton(SearchByParameters),
                },
            })
            {
                ResizeKeyboard = true,
                Selective = true
            };

            await botClient.SendTextMessageAsync(update.GetChat(), "выфвфыв", replyMarkup: keyboard, cancellationToken: cancellationToken);
        }

        public async Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Message == null)
                return;
            
            if (update.Message.Text == SearchByName)
            {
                await botClient.SendTextMessageAsync(update.GetChat(), SearchByName);
            }
            else if (update.Message.Text == SearchByParameters)
            {
                _messageReceiver.EnterStateOf<SearchByParametersState>(botClient, update, cancellationToken);
                // await botClient.SendTextMessageAsync(update.GetChat(), Resources.SearchByParameters);
            }
            else
            {
                await botClient.SendTextMessageAsync(update.GetChat(), "Не понял тебя, попробуй еще раз!");
            }
        }

        public async Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var remove = new ReplyKeyboardRemove();
            await botClient.SendTextMessageAsync(update.GetChat(), "", replyMarkup: remove, cancellationToken: cancellationToken);
        }
    }
}