using ES_SQL_DDD_CQRS.Infra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static ES_SQL_DDD_CQRS.Infra.EventStore.EventStoreInterface;

namespace ES_SQL_DDD_CQRS.Infra.EventStore
{
    public static class EventQueue
    {
        public static List<EventFromES> publishingQueue = new List<EventFromES>();

        public static void Queue(EventFromES theEvent)
        {

            publishingQueue.Add(theEvent);
            while (publishingQueue.Count > 0)
            {
                EventDistributor.Publish(publishingQueue[0]);
                if (publishingQueue.Count > 0) { publishingQueue.RemoveAt(0); }
            }
        }
        
    }
    
}
