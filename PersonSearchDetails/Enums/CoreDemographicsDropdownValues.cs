using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCIS.Specs.Enums
{
    internal class CoreDemographicsDropdownValues
    {

        //If we want the index value we can convert the enum using the code similar to below
        //I.E. prefix our enum with (int)
        //int valueWeWant = (int) LivesAloneValues.yes;

        public enum LivesAloneValues
        {
            yes,                //0
            no,                 //1
            declinesToDisclose, //2
            unknown             //3
        }







    }
}
