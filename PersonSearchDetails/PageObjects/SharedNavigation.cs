using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.PageObjects
{
    internal class SharedNavigation
    {
        //Public methods

        //Click Save

        public static void ClickSave(IWebDriver driver, Browser xrmBrowser)
        {
            xrmBrowser.CommandBar.ClickCommand("SAVE");
            WaitUntilSaveCompletes(driver);
            //The below has been commented out until a resolution can be investigated further, currently not working
            isGPStartDateValidationIconDisplayed(driver);

        }

        //Select Person Search
        public static void ClickPersonSearch(IWebDriver driver, Browser xrmBrowser)
        {
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            WaitUntilPersonSearchIsVisible(driver);
        }

        //Select People from command bar
        public static void ClickPeople(Browser xrmBrowser)
        {
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
        }

        //Select New Person from command bar
        public static void ClickNewPerson(Browser xrmBrowser)
        {
            xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
        }


        //Private methods

        //Wait until Save completes

        private static void WaitUntilSaveCompletes(IWebDriver driver)
        {
            double maxWait = 30; 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("\"savefooter_statuscontrol\"")));
            // You could find the element using: IWebElement savingWheelImage = driver.FindElement(By.Id("savefooter_statuscontrol"));
        }

        //Wait until the Person Search window is visible

        private static void WaitUntilPersonSearchIsVisible(IWebDriver driver)
        {
            double maxWait = 30;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("CWHeaderTitle")));
        }

        //Check to see if the GP Start Date validation icon is displayed when attempting to Save
        //NOTE: This is unfinished at this time
        private static void isGPStartDateValidationIconDisplayed(IWebDriver driver)
        {
            //DHCWExtensions.ClosePersonSearchResultsWindowIfOpen(driver, " Person Search ");
            //Ensure we are on the correct browser
            //Note: this was  necessary after adding the check for the GP Start Date validation icon when Save is clicked, it couldnt find the contentIFrame1)
            driver.SwitchTo().Window(driver.WindowHandles.First());
            //Switch to correct iFrame
            driver.SwitchTo().Frame("contentIFrame1");
            bool gpStartDateValidation = driver.IsVisible(By.XPath("//*[@id=\"cw_gpstartdate_warn\"]"));
            if (gpStartDateValidation)
            {
                //If the GP Validatio icon has bee found, throw this exception
                throw new Exception("Check the order of entry for the GP details, GP Start Date should be entered after the GP Name field");

            }
        }

        //Select New Person

        //Navigate to People

        //Navigate to Referrals 

        //etc.
    }
}
