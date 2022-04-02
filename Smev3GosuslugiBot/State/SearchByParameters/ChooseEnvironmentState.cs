﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev3GosuslugiBot.State.SearchByParameters
{
    public class ChooseEnvironmentState : IState
    {
        private readonly IMessageReceiver _messageReceiver;

        public ChooseEnvironmentState(IMessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
        }
    
        public async Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new[]
            {
                new List<KeyboardButton> { new KeyboardButton("Продуктивная среда") },
                new List<KeyboardButton> { new KeyboardButton("Тестовая среда") },
            }) 
            {
                ResizeKeyboard = true,
                Selective = true
            };
        
            await botClient.SendTextMessageAsync(update.GetChat(), "Выберите среду", replyMarkup: keyboard,
                cancellationToken: cancellationToken);
        }

        public Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is null)
                return Task.CompletedTask;

            if (update.Message.Text is "Тестовая среда")
            {
                _messageReceiver.EnterStateOf<WriteIdState>(botClient, update, cancellationToken);
            }
        
            else if (update.Message.Text is "Продуктивная среда")
            {
                _messageReceiver.EnterStateOf<WriteIdState>(botClient, update, cancellationToken);
            }

            else
            {
            
            }
        
            return Task.CompletedTask;
        }

        public Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}