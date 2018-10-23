using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Lab_13
{
    partial class Program
    {
        // функция для делегата-генерации коллекции
        public static List<Animal> GetRandomList(int count)
        {
            List<Animal> randomList = new List<Animal>();
            for (int i = 0; i < count; i++)
            {
                Animal value = GetValue(i).BaseAnimal;
                randomList.Add(value);
            }
            return randomList;
        }
        private static Bird GetValue(int key)
        {
            return new Bird("Bird_№_" + key.ToString(), key + 10, key + 10);
        }
        // функция для делегата-сортировки коллекции
        public static void SortList( List<Animal> list)
        {
            list.Sort(new NameComparer());
        }


        static void Main(string[] args)
        {
            //создаём коллекции и журналы
            Journal animalsOnly = new Journal();
            Journal bothCollections = new Journal();
            MyEventQueue<Animal> animals = new MyEventQueue<Animal>("Animals");
            MyEventQueue<Animal> zoo = new MyEventQueue<Animal>("Zoo");
            //определяем функции для делегатов
            animals.genList = GetRandomList;
            animals.sortList = SortList;
            zoo.genList = GetRandomList;
            zoo.sortList = SortList;
            //подписка на события
            animals.CollectionCountChanged+= animalsOnly.OnCollectionCountChanged;
            animals.CollectionReferenceChanged += animalsOnly.OnCollectionReferenceChanged;
            animals.Sorted += animalsOnly.OnSorted;
            animals.CollectionReferenceChanged += bothCollections.OnCollectionReferenceChanged;
            zoo.CollectionReferenceChanged += bothCollections.OnCollectionReferenceChanged;


            //изменения в коллекциях
            animals.Generate(6);
            zoo.Generate(10);
            animals.Sort();
            animals[4] = new Animal("Man", 75);
            zoo[4] = new Animal("ManLike", 45);
            animals.Enqueue(new Animal("Piter", 75));
            animals.Dequeue();
            animals.Remove(2);
            animals[2] = new Animal("Human", 75);
            zoo[4] = new Animal("Female", 75);
            animals.Clear();

            // вывод записей из журналов
            animalsOnly.PrintRecors();
            bothCollections.PrintRecors();
            Console.ReadLine();
        }

        //класс - компаратор для сортировки
        class NameComparer : IComparer<Animal>
        {
            public int Compare(Animal a1, Animal a2)
            {
                if (a1.Weight < a2.Weight)
                    return 1;
                else if (a1.Weight > a2.Weight)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
