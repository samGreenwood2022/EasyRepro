﻿using Microsoft.Dynamics365.UIAutomation.Api;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using WCCIS.Specs.PageObjects;
using WCCIS.Specs.Extentions;

namespace PersonSearchDetails.PageObjects
{
    internal class PersonMethods
        // a collection of methods that can be used in the Person area of CareDirector
    {



        // THIS DOES NOT FOLLOW THE PAGE OBJECT PATTERN - WE MAY NEED TO RECONSIDER WHERE THIS FILE SHOULD LIVE


        public static string dateMovedInNew = "01/01/2003";
        public string lastName { get; set; }

        // this method completes the mandatory fields required to add a valid address to a Person
        public static void enterAddressDetails(Browser xrmBrowser, IWebDriver driver, string propertyNo, string firstLineOfAddress, string townCity, string county, string postCode)
        {

            throw new NotImplementedException("");
    
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

        public static string personSearch(Browser xrmBrowser, IWebDriver driver, string firstname, string lastName, string dob)
        {
            // search for our person, the search person method should be called from here
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtLastName")).SendKeys(lastName);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtDOB")).SendKeys(dob);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(2000);

            // finds the element that stores the person id by searching on a partial id
            // then getting the text value from that element
            String personId = driver.FindElement(By.XPath("//*[contains(@id, 'cw_clientid')]")).Text;
            Console.WriteLine(personId);
            // the Actions class contains functions like 'doubleClick' which can be used on ui elements
            Actions act = new Actions(driver);
            IWebElement row = driver.FindElement(By.XPath("//*[text()[contains(.,'" + firstname + "')]]"));
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



    }
}
