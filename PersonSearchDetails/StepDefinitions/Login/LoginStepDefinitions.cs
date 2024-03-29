using Microsoft.Dynamics365.UIAutomation.Api;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public LoginStepDefinitions( Browser browser, IWebDriver webDriver)//constructor
        {
            // Create an instance of our webbrowser (defined in the Hooks) to be used by all methods in this class
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [Given(@"that i've logged in as an administrator")]
        public void GivenThatIveLoggedInAsAnAdministrator()
        {
            // call our AdministratorLogin method
            UserLogin.AdministratorLogin(xrmBrowser, driver);
            // removes any popups displayed when we 1st log in
            xrmBrowser.ThinkTime(2000);
            try
            {
                driver.SwitchTo().Frame("InlineDialog_Iframe");
                xrmBrowser.ThinkTime(2000);
                driver.FindElement(By.XPath("//*[@id=\"butBegin\"]")).Click();

            }
            catch
            {
                Console.WriteLine("No popup displayed");

            }
            // check to ensure the caredirector logo is displayed
            driver.FindElement(By.XPath("//*[@id=\"navTabLogoTextId\"]/img"));
        }

        [Given(@"that an adult support worker has logged in")]
        public void GivenThatAnAdultSupportWorkerHasLoggedIn()
        {
            // call our AdministratorLogin method
            UserLogin.AdultSupportWorkerLogin(xrmBrowser, driver);
            // removes any popups displayed when we 1st log in
            xrmBrowser.ThinkTime(2000);
            try
            {
                driver.SwitchTo().Frame("InlineDialog_Iframe");
                xrmBrowser.ThinkTime(2000);
                driver.FindElement(By.XPath("//*[@id=\"butBegin\"]")).Click();

            }
            catch
            {
                Console.WriteLine("No popup displayed");

            }
            // check to ensure the caredirector logo is displayed
            driver.FindElement(By.XPath("//*[@id=\"navTabLogoTextId\"]/img"));
        }

        [Given(@"that a childrens support worker has logged in")]
        public void GivenAChildrensSupportWorkerHasLoggedIn()
        {
            // call our AdministratorLogin method
            UserLogin.ChildrensSupportWorkerLogin(xrmBrowser, driver);
            // removes any popups displayed when we 1st log in
            xrmBrowser.ThinkTime(2000);
            try
            {
                driver.SwitchTo().Frame("InlineDialog_Iframe");
                xrmBrowser.ThinkTime(2000);
                driver.FindElement(By.XPath("//*[@id=\"butBegin\"]")).Click();

            }
            catch
            {
                Console.WriteLine("No popup displayed");

            }
            // check to ensure the caredirector logo is displayed
            driver.FindElement(By.XPath("//*[@id=\"navTabLogoTextId\"]/img"));
        }


    }
}
