using ES_SQL_DDD_CQRS.Infra.EventStore;
using System.Collections.Generic;
using static ES_SQL_DDD_CQRS.Infra.EventStore.EventStoreInterface;

namespace ES_SQL_DDD_CQRS.Infra
{
    public class EventStream
    {
        public List<EventFromES> events = new List<EventFromES>();
        public void Set(EventFromES eventToAdd)
        {
            events.Add(eventToAdd);
        }
        public EventFromES Get(EventFromES eventToGet)
        {
            EventFromES eventGotten = null;

            if (events.Contains(eventToGet))
            {
                eventGotten = events.Find(x => x.Id == eventToGet.Id);
            }
            return eventGotten;
        }
    }

}
