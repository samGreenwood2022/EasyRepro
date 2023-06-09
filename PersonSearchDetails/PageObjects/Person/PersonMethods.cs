using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonSearchDetails.PageObjects
{
    internal class PersonMethods
        // a collection of methods that can be used in the Person area of CareDirector
    {



        // THIS DOES NOT FOLLOW THE PAGE OBJECT PATTERN - WE MAY NEED TO RECONSIDER WHERE THIS FILE SHOULD LIVE


        public static string dateMovedInNew = "01/01/2003";
        private static string field;
        private static bool elementTrue;
        private static string fieldExpected;

        public string lastName { get; set; }

        public static bool IsPersonMandatoryFieldValidationErrorPresent(Browser xrmBrowser, IWebDriver driver, Enum enumFieldExpected)
        {
            // convert enum to string
            fieldExpected = enumFieldExpected.ToString();
            // this needs to be changes to use the reference data instead, ie enu

            // switch to the last open browser window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            // click Save fro the command bar
            driver.FindElement(By.Id(@"contact|NoRelationship|Form|Mscrm.Form.contact.Save")).Click();
            xrmBrowser.ThinkTime(500);
            // set default value for element found to be false
            bool elementFound = false;
            // dob validation is different to the other fields as its displayed in an alert instead of the validation message inline with the field
            // this if statement is to cater for the alert instead of the regular validation messages
            if (fieldExpected == "dob")
            {
                // check the presence of alert and get the text it contains
                string alertText = driver.SwitchTo().Alert().Text;
                Console.WriteLine(alertText);
                // assert the alert text is as expected
                Assert.IsTrue(alertText.Contains("Please enter estimated age or DOB."));
                // close the alert
                driver.SwitchTo().Alert().Dismiss();
                // set elementFound to be true
                elementFound = true;
                return elementFound;
            }
            else // if we arent dealing with the dob field then run the following code to test the other validation messages
            {
                // select the correct iFrame
                driver.SwitchTo().Frame("contentIFrame1");
                // get all instances of class 'ms-crm-Inline-Validation'
                IList<IWebElement> wei = driver.FindElements(By.ClassName("ms-crm-Inline-Validation"));

                //Loop through all elements returned in the above array 
                foreach (IWebElement element in wei)
                {
                    //Only check next element, if you haven't found the one you're looking for
                    if (!elementFound)
                    {
                        // get the text content for the validation message
                        string a = element.GetAttribute("textContent");
                        // get the style of the validation message, should equal 'display: block;' if visible
                        string b = element.GetAttribute("style");
                        // switch/case statement where expression needs to match case
                        // how do we pass in the field we are checking, create class with field values? where to store?
                        switch (fieldExpected)
                        {
                            //switch statement then executes code which looks for the error of each type
                            //ethnicity
                            case "ethnicity":
                                if (a == "You must provide a value for Ethnicity." && b.Contains("display: block;"))
                                {
                                    // set elementFound to be true and return our value
                                    elementFound = true;
                                    return elementFound;

                                }
                                break;
                            //gender 
                            case "gender":
                                if (a == "You must provide a value for Gender." && b.Contains("display: block;"))
                                {
                                    // set elementFound to be true and return our value
                                    elementFound = true;
                                    return elementFound;

                                }
                                break;
                            //lastName
                            case "lastName":
                                if (a == "You must provide a value for Last Name." && b.Contains("display: block;"))
                                {
                                    // set elementFound to be true and return our value
                                    elementFound = true;
                                    return elementFound;
                                }
                                break;
                            //movedInDate
                            case "movedInDate":
                                if (a == "You must provide a value for Date Person moved in." && b.Contains("display: block;"))
                                {
                                    // set elementFound to be true and return our value
                                    elementFound = true;
                                    return elementFound;
                                }
                                break;
                        }
                    }
                }

            }
            return elementFound;
        }

    }
}

