using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Extentions
{
    public static class DHCWExtentions
    {       // this code will log us into CareDirector
        public static void Login(Api.Browser xrmBrowser, SecureString _username, SecureString _password)
        {
            // wait for page to load
            var driver = xrmBrowser.Driver;
            xrmBrowser.ThinkTime(2000);
            driver.Navigate().GoToUrl("https://caredirectoruat365.ccis.cymru");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"bySelection\"]/div[2]/img")).Click();
            // driver.FindElement(By.XPath("//*[@id=\"bySelection\"]/div[6]/div/span")).Click();
            
            // wait for page to load
            xrmBrowser.ThinkTime(1000);
            // ADFS login screen
            driver.FindElement(By.Id("userNameInput")).SendKeys(_username.ToUnsecureString());
            driver.FindElement(By.Id("passwordInput")).SendKeys(_password.ToUnsecureString());
            driver.FindElement(By.Id("submitButton")).Click();
            // xrmBrowser.ThinkTime(2000);
        }

        // Generate a random string with a given size
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

    }
}
