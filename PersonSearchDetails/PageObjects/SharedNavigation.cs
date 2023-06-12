using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //Select New Person

        //Navigate to People

        //Navigate to Referrals 

        //etc.
    }
}
