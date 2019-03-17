using System;

namespace dk.lashout.LARPay.Administration
{
    public sealed class Messages
    {
        private readonly IServiceProvider _provider;

        public Messages(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public void Dispatch (ICommand command)
        {
            Type commandHandlerType = typeof(ICommandHandler<>);
            Type[] commandType = { command.GetType() };
            Type genericHandlerType = commandHandlerType.MakeGenericType(commandType);

            dynamic handler = _provider.GetService(genericHandlerType);
            handler.Handle((dynamic)command);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            Type queryHandlerType = typeof(IQueryHandler<,>);
            Type[] queryType = { query.GetType(), typeof(T) };
            Type genericHandlerType = queryHandlerType.MakeGenericType(queryType);

            dynamic handler = _provider.GetService(genericHandlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }

        public void Dispatch(IEvent @event)
        {
            Type eventObserverType = typeof(IEventObserver<>);
            Type[] eventType = { @event.GetType() };
            Type genericObserverType = eventObserverType.MakeGenericType(eventType);

            dynamic observer = _provider.GetService(genericObserverType);
            observer.Update((dynamic)@event);
        }
    }
}
