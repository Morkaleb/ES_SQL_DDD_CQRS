using ES_SQL_DDD_CQRS.Infra.EventStore;

namespace ES_SQL_DDD_CQRS.Infra.ReadModels
{
    public abstract class ReadModel
    {
        public abstract dynamic EventPublish(EventFromES anEvent);
    }
}
