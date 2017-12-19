using ES_SQL_DDD_CQRS.Infra.EventStore;
using ES_SQL_DDD_CQRSL.Infra.Sql;
using EventStore.ClientAPI;

namespace ES_SQL_DDD_CQRS.Infra
{
    public class OnStart
    {
         public static void Start()
        {
            TableReadmodelInterface.CheckForTables();
            EventStoreInterface.StartConnection();
            EventStoreInterface.ReadSavedEvents();
         }                
    }
}
