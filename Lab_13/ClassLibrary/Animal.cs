using System;
using System.Runtime.InteropServices;

namespace ClassLibrary
{
    // Это базовый класс - Животное
    public class Animal: IComparable, IEquatable<Animal>
    {
        // задаём значения по умолчанию для обработки исключений 
        protected string name="DefaultName";
        protected double weight=0;
        public Animal()
        {

        }
        //конструктор с параметрами
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        // получение доступа к полям класса
        public string Name
        {
            set
            {
                if (value.Length > 0) name = value;
            }
            get { return name; }
        }
        public double Weight
        {
            set
            {
                if (value > 0) weight = value;
            }
            get { return weight; }
        }

        public override string ToString()
        {
            return Name;
        }
        // виртуальный метод
        public virtual void ShowCreature()
        {
            Console.WriteLine("Это животное. Его зовут {0}. Оно весит {1} килограммов.", name, weight);
        }


        // реализуем интерфейс IComparable для использования сортировки
        public int CompareTo(object obj)
        {
            Animal compar = (Animal)obj;
            // сравнение происходит по продолжительности жизни
            if (Weight > compar.Weight) return 1;
            if (Weight < compar.Weight) return -1;
            return 0;
        }

        // реализуем интерфейс IEquitable использования поиска элементов
        public bool Equals(Animal an1)
        {
            if (this.name == an1.Name && this.weight == an1.Weight) return true;
            return false;
        }
        public override bool Equals(Object obj)
        {
            return Equals((Animal)obj);
        }

        public override int GetHashCode()
        {
            return this.Weight.GetHashCode() ^ this.Name.GetHashCode();
        }
        public virtual object Clone()
        {
            return new Animal(this.name, this.weight);
        }
    }
}
