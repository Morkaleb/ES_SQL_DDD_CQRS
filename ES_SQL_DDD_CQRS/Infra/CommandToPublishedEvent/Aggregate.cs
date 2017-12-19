using ES_SQL_DDD_CQRS.Infra.EventStore;

namespace ES_SQL_DDD_CQRS.Infra
{
    public abstract class Aggregate
    {
        public abstract void Hydrate(EventFromES evt);
        public abstract void Execute(Commands cmd);
    }
}
