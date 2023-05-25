using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using WCCIS.Specs.PageObjects;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects.Person;

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

        // this method completes the mandatory fields required to add a valid address to a Person
        public static void enterAddressDetails(Browser xrmBrowser, IWebDriver driver, string propertyNo, string firstLineOfAddress, string townCity, string county, string postCode)
        {

            throw new Exception("No longer maintained, please use individual step methods from relevan page object.");
    
            Page_PersonCoreDemographics.EnterPropertyNumber(driver, propertyNo);
            Page_PersonCoreDemographics.EnterFirstLineOfAddress(driver, firstLineOfAddress);
            Page_PersonCoreDemographics.EnterTownCity(driver, townCity);
            Page_PersonCoreDemographics.EnterCounty(driver, county);
            Page_PersonCoreDemographics.EnterPostCode(driver, postCode);
           
            // click postcode lookup
            // driver.FindElement(By.XPath("//*[@id=\"address1_postalcodeAddressSearch\"]")).Click();
            xrmBrowser.ThinkTime(2000);
            xrmBrowser.CommandBar.ClickCommand("SAVE");
            xrmBrowser.ThinkTime(1000);
        }

        //Ideally we would be splitting the person search into the individual steps in the method where it is called 
        public static string personSearch(Browser xrmBrowser, IWebDriver driver, string firstName, string lastName, string dob)
        {

            throw new Exception("Method no longer maintained. Use individual step methods defined in Page_PersonSearch class.")
            // search for our person, the search person method should be called from here
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);

            Page_PersonSearch.EnterTextIntoFirstNameField(driver, firstName);
            Page_PersonSearch.EnterTextIntoLastNameField(driver, lastName);
            Page_PersonSearch.EnterDateOfBirth(driver, dob);
            Page_PersonSearch.ClickSearch(driver);

            //assuming the code below will find the box that has the person ID from the search results
            //Then will pull the text from that
            //Then will doubleClick on the box that contains the first name
            //Then the person ID is returned
            //This one needs some thought

            // finds the element that stores the person id by searching on a partial id
            // then getting the text value from that element
            String personId = driver.FindElement(By.XPath("//*[contains(@id, 'cw_clientid')]")).Text;
            Console.WriteLine(personId);
            // the Actions class contains functions like 'doubleClick' which can be used on ui elements
            Actions act = new Actions(driver);
            IWebElement row = driver.FindElement(By.XPath("//*[text()[contains(.,'" + firstName + "')]]"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(2000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.Close();
            // switch to the correct browser window and iFrame we want to use
            // driver.SwitchTo().Window(driver.WindowHandles.First());
            // driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            // driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));
            xrmBrowser.ThinkTime(2000);
            return personId;
        }

        public static string CreateBasicPerson(Browser xrmBrowser, IWebDriver driver, string firstName, string dob, string dateMovedIn, string ethnicity, string gender, string preferredLanguage,string lastName)
        {
            throw new Exception("This method is deprecated in favour of individual steps for maintenance reasons. It will be deleted in the future");
            // this method will create a basic new person, the way the tests are structured means that the lastName needs to be generated outside of this method, its them passed into this method to be used as the lastName
            // for example, PER0005 needs to create 2 identical people, if the random lastName generator was used here we couldnt create 2 identical people, as the lastName would be random

            // create a basic person using mandatory fields only plus the firstname field
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            // select the correct iFrame
            driver.SwitchTo().Frame("contentIFrame1");
            xrmBrowser.ThinkTime(1000);

            Page_PersonCoreDemographics.EnterFirstName(driver, firstName);
            Page_PersonCoreDemographics.EnterLastName(driver, lastName);
            Page_PersonCoreDemographics.EnterEthnicity(driver, ethnicity);
            Page_PersonCoreDemographics.EnterPreferredLanguage(driver, preferredLanguage);
            Page_PersonCoreDemographics.EnterGender(driver, gender);
            Page_PersonCoreDemographics.EnterDateOfBirth(driver, dob);
            Page_PersonCoreDemographics.EnterDateMovedIn(driver, dateMovedIn);

            // save the record
            xrmBrowser.CommandBar.ClickCommand("SAVE");
            xrmBrowser.ThinkTime(3000);
            Console.WriteLine(lastName);

            return lastName;

        }

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

