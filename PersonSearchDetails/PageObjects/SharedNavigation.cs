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
        //Click Save

        public static void ClickSave(IWebDriver driver, Browser xrmBrowser)
        {
            xrmBrowser.CommandBar.ClickCommand("SAVE");
            WaitUntilSaveCompletes(driver);
        }

        private static void WaitUntilSaveCompletes(IWebDriver driver)
        {
            double maxWait = 30; 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("\"savefooter_statuscontrol\"")));
            // You could find the element using: IWebElement savingWheelImage = driver.FindElement(By.Id("savefooter_statuscontrol"));
        }

        //Select New Person

        //Navigate to People

        //Navigate to Referrals 

        //etc.
    }
}
