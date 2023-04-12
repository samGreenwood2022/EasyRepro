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

        public LoginStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
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
            LoginCredentials.AdministratorLogin(xrmBrowser, driver);
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

        [Given(@"that i've logged in as a social worker")]
        public void GivenThatIveLoggedInAsSocialWorker()
        {
            // call our AdministratorLogin method
            LoginCredentials.SocialWorkerLogin(xrmBrowser, driver);
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

        [Given(@"that i've logged in as a social worker")]
        public void GivenThatIveLoggedInAsCareWorker()
        {
            // call our AdministratorLogin method
            LoginCredentials.CareWorkerLogin(xrmBrowser, driver);
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
