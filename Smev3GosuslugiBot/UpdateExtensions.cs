using System;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Smev3GosuslugiBot
{
    public static class UpdateExtensions
    {
        public static User GetUser(this Update update)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    return update.Message.From;
                case UpdateType.CallbackQuery:
                    return update.CallbackQuery.From;
                default:
                    return null;
            }
        }
        public static Chat GetChat(this Update update)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    return update.Message.Chat;
                case UpdateType.CallbackQuery:
                    return update.CallbackQuery.Message.Chat;
                default:
                    return null;
            }
        }
    }
}