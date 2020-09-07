using Session05Animals;
using System;

namespace Sesseion05Exc01
{
    class Program
    {
        static void Main(string[] args)
        {
            var beanType = CupOfCoffee.DefaultBeanType;

            Animal myAnimal = new Chicken(1);
            myAnimal = new Cow(2);

            // casting
            //tvingad datakonvertering
            // genererar InvalidCastException
            Cow myCow = (Cow)myAnimal;

            // saker datakonvertering
            // blir null om typen inte gar att konvertera
            myCow = myAnimal as Cow;

            IBarnYardAnimal barnYardAnimal = new Chicken(1);
            myBarnYardAnimal.FeedingArea = "Main yard";


            Chicken myChicken = new Chicken(1);
        }
    }
}
