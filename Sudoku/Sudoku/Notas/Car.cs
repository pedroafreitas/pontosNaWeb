using System;

namespace Sudoku.Notas
{
    abstract class Car
    {
        protected bool On;
        
        public bool TurnOnOff()
        {
            Random rand = new Random();
            On = rand.Next(2) == 1;
            On = !On;
            Console.WriteLine(On ? "car is on" : "car is off");
                
            return On;
        }

        public abstract void Drive();
    }
}