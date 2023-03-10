using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Extentions
{
    public static class DHCWExtentions
    {
        public static void Login(Api.Browser xrmBrowser, SecureString _username, SecureString _password)
        {
            // wait for page to load
            var driver = xrmBrowser.Driver;
            xrmBrowser.ThinkTime(2000);
            driver.Navigate().GoToUrl("https://caredirectoruat365.ccis.cymru");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"bySelection\"]/div[6]/div/span")).Click();
            // wait for page to load
            xrmBrowser.ThinkTime(1000);
            // ADFS login screen
            driver.FindElement(By.Id("userNameInput")).SendKeys(_username.ToUnsecureString());
            driver.FindElement(By.Id("passwordInput")).SendKeys(_password.ToUnsecureString());
            driver.FindElement(By.Id("submitButton")).Click();
            xrmBrowser.ThinkTime(2000);
        }
    }
}
