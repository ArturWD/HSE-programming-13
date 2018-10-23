using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    public class CollectionHandlerEventArgs: EventArgs
    {
        public string collectionName { get; set; }
        public string alterType { get; set; }
        public object objectLink { get; set; }
        public CollectionHandlerEventArgs(string name, string alter, object link)
        {
            collectionName = name;
            alterType = alter;
            objectLink = link;
        }
        public override string ToString()
        {
            return $"Имя коллекции - {collectionName}. Тип изменений - {alterType}";
        }
    }  
}
