using System;
using System.Collections.Generic;
using System.Text;

namespace Session05Animals
{
    public class Chicken : Animal, IBarnYardAnimal
    {
        private string _restingArea;
        public string RestingArea => _restingArea;

        private string _feedingArea;

        public Chicken(int ageInYears) : base(ageInYears)
        {

        }
        //egenskapsdefinition
        public string FeedingArea 
        {
            get
            {
                return _feedingArea;
            }
            set
            {
                _feedingArea = value;
            }
        }

        public override void EatFood()
        {
            /*implementation av metoden*/
            /* fyller metoden med logik*/
            throw new NotImplementedException();
        }
    }
}
