using System;
using System.Collections.Generic;
using System.Text;

namespace Session05Animals
{
    public class Cow : Animal
    {
        public Cow(int ageInYears) : base(ageInYears)
        {
        }

        /// <summary>
        /// create an instance of a cow object
        /// </summary>
        public override void EatFood()
        {
            /* Denna metod saknar implementation, men der ar oker for att det finns ingen returtyp */
        }

        //metod
        public void SupplyMilk()
        {

        }

    }
}
