using System;
using System.Collections.Generic;
using ES_SQL_DDD_CQRS.Infra.EventStore;

namespace ES_SQL_DDD_CQRS.Infra
{
    public static class CommandHandler
    {
        public static  void ActivateCommand(Commands cmd, Aggregate aggregate)
        {
            List<EventFromES> eventStream = new List<EventFromES>();
            try
            {
                eventStream = EventStoreInterface.HydrateFromES(cmd.Id);
            }catch (Exception e) { Console.Write(e); }
            if(eventStream.Count > 0)
            {             
                foreach (var evt in eventStream)
                {
                    aggregate.Hydrate(evt);
                }
                
            }
            aggregate.Execute(cmd);
        }
    }
}
