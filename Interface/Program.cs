﻿using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(200, 70);
            Bus bus1 = new Bus(100, 24) { Capacity = 30 };
            Hourse hourse1 = new Hourse() { Vehicle = 40 };
            IMovable inter1 = new Hourse() { Vehicle = 32 };

            car1.Move();
            bus1.Move();
            IFileWork file = (IFileWork)hourse1;
            file.Move();
            inter1.Move();
            Console.WriteLine(inter1.GetType());
            Print(bus1);
        }

        //Метод будет работать со всеми классами, реализующими интерфейс и только c составляющими,
        //которые были определены в интерфейсе
        public static void Print(IMovable obj)
        {
            obj.Move();
            Console.WriteLine(obj.Vehicle);
            Console.WriteLine(obj.GetType());
            if (obj is Car) {
                Car obj2 = (Car)obj;
                Console.WriteLine(obj2.Color); }
        }
    }

    interface IMovable
    {
        int Vehicle { get; set; }
        void Move();
        
        void Info();
    }

    interface IFileWork
    {
        int Vehicle { get; set; }
        void Move();
    }

    abstract class Animal
    {
        public int Legs { get; set; } = 4;
    }

    abstract class Machine : IMovable
    {
        public int HoursePower { get; set; }
        public int Vehicle { get; set; }

        public abstract void Move();
        public abstract void Info();
    }

    class Car : Machine
    {
        public string Color { get; set; } = "Black";
         public Car(int veh)
        {
            Vehicle = veh;
        }

        public Car(int veh, string color) : this(veh)
        {
            Color = color;
        }

        public Car(int veh, int hoursepower) : this(veh)
        {
            HoursePower = hoursepower;
        }

        public Car(int veh,int hoursepower, string color) : this(veh, hoursepower)
        {
            Color = color;
        }

        public override void Info()
        {
            Console.WriteLine($"vehicle = {Vehicle}, hoursepower = {HoursePower}, color = {Color}");
        }

        public override void Move()
        {
            Console.WriteLine($"Moving with vehicle {Vehicle}");
        }
    }

    class Bus : Car, IMovable
    {
        public int Capacity { get; set; } // set explicitly with { capacity = smth }
        public Bus(int veh) : base(veh)
        {
        }

        public Bus(int veh, string color) : base(veh, color)
        {
        }

        public Bus(int veh, int hoursepower) : base(veh, hoursepower)
        {
        }

        public Bus(int veh, int hoursepower, string color) : base(veh, hoursepower, color)
        {
        }

        //Используется явная реализация интерфейса, т.к. наследуемый класс Bus переопределяет метод интерфейса IMovable
        void IMovable.Move()
        {
            Console.WriteLine($"Moving with vehicle {Vehicle}");
        }
    }

    class Hourse : Animal, IMovable, IFileWork
    {
        public int Vehicle { get; set; }
        public void Info()
        {
            Console.WriteLine($"Vehicle = {Vehicle}");
            Console.WriteLine($"This is hourse with vehicle {Vehicle}");
        }
        
        //Используется явная реализация, так как у двух разных интерфейсов реализуется метод с одинаковым называнием
        void IMovable.Move()
        {
            Console.WriteLine($"This is hourse with vehicle {Vehicle}");
        }

        void IFileWork.Move()
        {
            Console.WriteLine("File is moving to <<path>>");
        }

    }

}