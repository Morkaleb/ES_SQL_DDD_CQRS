using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ES_SQL_DDD_CQRS.Infra
{
    public static class Book
    {
       public static Dictionary<string, List<ReadModelData>> book = new Dictionary<string, List<ReadModelData>>();
    }
}