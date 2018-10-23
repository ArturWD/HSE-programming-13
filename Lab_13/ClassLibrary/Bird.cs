using System;

namespace ClassLibrary
{
    // Это производный класс - Птица. Птица - производный класса от животного.
    public class Bird:Animal, ICloneable, IEquatable<Bird>
    {
        // задаём значения по умолчанию для обработки исключений 
        protected int flightDistance = 0;

        //конструктор без параметров
        public Bird():base()
        {
            
        }
        //конструктор с параметрами
        public Bird(string name, double weight, int flightDistance):base(name, weight)
        {
            FlightDistance = flightDistance;
        }

        // получение доступа к полям класса
        public int FlightDistance
        {
            set
            {
                if (value > 0) flightDistance = value;
            }
            get { return flightDistance; }
        }
      

        // переопределённый виртуальный метод
        public override void ShowCreature()
        {
            Console.WriteLine("Это птица. Её зовут {0}. Она может пролететь до {1} километров за раз.", name, flightDistance);
        }


        // реализуем метод интерфейса ICloneable
        public override object Clone()
        {
            return new Bird(this.name, this.weight, this.flightDistance);
        }

 
        public Animal BaseAnimal
        {
            get { return new Animal(name, weight); }
        }

        public bool Equals(Bird an1)
        {
            if (name == an1.Name && weight == an1.Weight && flightDistance == an1.flightDistance) return true;
            return false;
        }

        public override string ToString()
        {
            return Name+' '+weight+' '+flightDistance;
        }
    }
}
