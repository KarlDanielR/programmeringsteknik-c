using System;
using System.Collections.Generic;
using System.Text;

namespace Sesseion05Exc01
{
    class CupOfCoffee
    {
        //Statiskt falt delat for hela klassen.
        public static string DefaultBeanType = "Arabica";
        public static string[] BeanTypes;

        public string BeanType;
        public bool Instant;
        public bool Milk;
        public byte SugarCubes;
        public string Description;

        private string _id;
        //statisk konstruktor
        public CupOfCoffee()
        {
            BeanTypes = new[]
            {
                "Arusha",
                "Arabica",
                "Blue Mountain",
                "Robusta"
            };
            /*Ovan ar samma sak som:
             BeanTypes = new string[4];
            BeanTypes[0] = "Arusha"
            BeanTypes[1] = "Arabica"
            osv.... */

        }



        //konstruktor
        //identiskt namn med klassen
        

        //konstruktor med inparametrar (samma namnstandard som lokala variabler)
        public CupOfCoffee(bool milk, byte sugarCubes)
        {
            SugarCubes = sugarCubes;
            Milk = milk;
        }
        // finalizer eller destruktor
        //ej nOdvandig om idisposable
        /*~CupOfCoffee
            { }*/


    }
}
