namespace WCCIS.Specs.Enums
{
    internal class MandatoryFields
    {
        //If we want the index value we can convert the enum using the code similar to below
        //I.E. prefix our enum with (int)
        //int valueWeWant = (int) PersonMandatoryFields.ethnicity;

        public enum PersonMandatoryFields
        {
            ethnicity,          //0
            preferredLanguage,  //1
            gender,             //2
            movedInDate,        //3
            lastName,           //4
            dob                 //5
        }

    }
}
