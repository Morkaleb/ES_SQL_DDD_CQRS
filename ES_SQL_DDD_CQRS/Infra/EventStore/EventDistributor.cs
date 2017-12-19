using ES_SQL_DDD_CQRS.Infra.EventStore;
using ES_SQL_DDD_CQRSL.Infra.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static ES_SQL_DDD_CQRS.Infra.EventStore.EventStoreInterface;

namespace ES_SQL_DDD_CQRS.Infra
{
    public static class EventDistributor
    {
        public static void Publish(EventFromES anEvent)
        {
            dynamic readmodelData;
            string nspace = "ES_SQL_DDD_CQRS.src.ReadModels";
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
                    select t;
            foreach (var readModel in q)
            {
                string[] hksd = readModel.Name.ToString().Split("Data");
                if (hksd.Length == 1) {
                    try
                    {
                        MethodInfo theMethod = typeof(ReadModels.ReadModel).GetMethod("EventPublish", new[] { typeof(EventFromES) });
                        string methodName = readModel.Name.ToString();
                        string nameSpace = readModel.Namespace.ToString();
                        string key = methodName.Split("Read")[0];
                        if (Book.book.ContainsKey(key))
                        {
                            string fullClassName = nameSpace + "." + methodName;
                            object readModelToInvoke = Activator.CreateInstance(Type.GetType(fullClassName));
                            readmodelData = theMethod.Invoke(readModelToInvoke, new EventFromES[] { anEvent });
                        }
                        else
                        {
                            Book.book.Add(key, new List<ReadModelData>());
                            string fullClassName = nameSpace + "." + methodName;
                            object readModelToInvoke = Activator.CreateInstance(Type.GetType(fullClassName));
                            readmodelData = theMethod.Invoke(readModelToInvoke, new EventFromES[] { anEvent });
                        }
                        TableReadmodelInterface.UpdateTable(readmodelData, key);
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                    }
                }
                

            }

        }
    }
}
