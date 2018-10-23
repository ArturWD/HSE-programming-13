using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    class Journal
    {
        List<JournalEntry> changesRecord;
        public Journal()
        {
            changesRecord = new List<JournalEntry>();
        }
        public JournalEntry this[int index]
        {
            set
            {
                if (index < 0 || index >= changesRecord.Count)
                    throw new IndexOutOfRangeException();
                changesRecord[index] = value;
            }
            get
            {
                return changesRecord[index];
            }
        }
        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            changesRecord.Add(new JournalEntry(e.collectionName, e.alterType, e.objectLink, ConsoleColor.Green));
        }
        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            changesRecord.Add(new JournalEntry(e.collectionName, e.alterType, e.objectLink, ConsoleColor.Red));
        }
        public void OnSorted(object source, CollectionHandlerEventArgs e)
        {
            changesRecord.Add(new JournalEntry(e.collectionName, e.alterType, e.objectLink, ConsoleColor.Magenta));
        }
        public override string ToString()
        {
            string allRecords = "ЖУРНАЛ" + "\n";
            foreach (var item in changesRecord) allRecords+=item.ToString()+"\n";
            return allRecords;
        }
        public void PrintRecors()
        {
            Console.WriteLine("ЖУРНАЛ");
            foreach (var item in changesRecord)
            {
                Console.ForegroundColor = item.color;
                Console.WriteLine(item.ToString());
                Console.ResetColor();
            }
        }
    }
}
