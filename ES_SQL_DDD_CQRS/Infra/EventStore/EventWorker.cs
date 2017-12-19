using ES_SQL_DDD_CQRS.Infra.EventStore;
using System;
using System.Linq;
using System.Reflection;


namespace ES_SQL_DDD_CQRS.Infra.EventStore
{
    public class EventWorker
    {
        public static void Work(Events evt)
        {
            evt.TimeStamp = DateTime.Now;
            EventStoreInterface.PublishToEventStore(evt);
        }
        
        private static object GetValues(object anEvent, string name)
        {
            return anEvent.GetType().GetProperties()
                .Single(pi => pi.Name == name)
                .GetValue(anEvent, null);
        }
    }
}
