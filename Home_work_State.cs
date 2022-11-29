using System;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();

            Console.Read();
        }
    }
    class Water
    {
        public IWaterState State { get; set; }

        public Water(IWaterState ws)
        {
            State = ws;
        }

        public void Heat()
        {
            State.Heat(this);
        }
        public void Frost()
        {
            State.Frost(this);
        }
    }

    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }

    class SolidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Лед -> Жидкость");
            water.State = new LiquidWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Продолжение заморозки Льда");
        }
    }
    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Жидкость -> Пар");
            water.State = new GasWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Жидкость -> Лед");
            water.State = new SolidWaterState();
        }
    }
    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Повышение Температуру Пара");
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Пар -> Жидкость");
            water.State = new LiquidWaterState();
        }
    }
}
