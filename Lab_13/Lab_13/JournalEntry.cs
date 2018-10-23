using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    class JournalEntry
    {
        public string collectionName { get; set; }
        public string alterType { get; set; }
        public string objectLink { get; set; }
        public ConsoleColor color;
        public JournalEntry(string name, string alter, object link, ConsoleColor textColor)
        {
            collectionName = name;
            alterType = alter;
            objectLink = link.ToString();
            color = textColor;
        }
        public override string ToString()
        {
            return $"Имя коллекции - {collectionName}. Тип изменений - {alterType}. Изменённый объект - {objectLink}";
        }

    }
}
