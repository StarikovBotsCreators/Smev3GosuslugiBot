using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.State;
using Smev3GosuslugiBot.State.SearchByParameters;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Smev3GosuslugiBot
{
    public class MessageReceiver : IUpdateHandler, IMessageReceiver
    {
        private Dictionary<long, Client> _stateOfPersons = new Dictionary<long, Client>();

        private Dictionary<Type, IState> _statePool;

        public MessageReceiver()
        {
            _statePool = new Dictionary<Type, IState>
            {
                { typeof(SetupState), new SetupState(this) },
                { typeof(HelloState), new HelloState(this) },
                { typeof(TypeInformationLevelState), new TypeInformationLevelState(this) },
                { typeof(SearchByParametersState), new SearchByParametersState(this) },
                { typeof(WriteIdState), new WriteIdState(this) },
                { typeof(ChooseEnvironmentState), new ChooseEnvironmentState(this) },
                { typeof(ChooseSubjectState), new ChooseSubjectState(this) },
                { typeof(ContextOfUseState), new ContextOfUseState(this) },
            };
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Type != UpdateType.Message && update.Type !=  UpdateType.CallbackQuery)
                return;
            
            Client client;
            Chat messageChat = update.GetChat();
            if (!_stateOfPersons.TryGetValue(messageChat.Id, out client))
            {
                EnterStateOf<SetupState>(botClient, update, cancellationToken);
                client.CurrentState = StateInstanceOf<SetupState>();
            }

            await client.CurrentState.Update(botClient, update, cancellationToken);
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.StackTrace);
            return Task.CompletedTask;
        }

        public Client GetCurrentClient(Update update)
        {
            return _stateOfPersons[update.GetUser().Id];
        }

        public void EnterStateOf<TState>(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken) where TState : IState
        {
            if(_stateOfPersons.TryGetValue(update.GetUser().Id, out Client client))
                client.CurrentState.Exit(botClient, update, cancellationToken);
            
            TState stateInstanceOf = StateInstanceOf<TState>();
            _stateOfPersons[update.GetUser().Id].CurrentState = stateInstanceOf;
            stateInstanceOf.Enter(botClient, update, cancellationToken);
        }

        private TState StateInstanceOf<TState>() where TState : IState
        {
            return (TState) _statePool[typeof(TState)];
        }
    }
}