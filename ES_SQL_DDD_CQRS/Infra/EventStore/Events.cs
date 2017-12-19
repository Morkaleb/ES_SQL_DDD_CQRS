using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ES_SQL_DDD_CQRS.Infra
{
    public abstract class Events
    {
        public string EventType { get; set; }
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
