using System;
using System.Collections.Generic;
using System.Text;

namespace Session05Animals
{
    public abstract class Animal
    {
        public int AgeInYears;

        public Animal(int ageInYears)
        {
            AgeInYears = ageInYears;
        }
        //abstrakt metoddefenition
        public abstract void EatFood();
        //konkret metoddefenition
        public void Breed()
        {
            /*this implementation does nothing*/
        }
    }
}
