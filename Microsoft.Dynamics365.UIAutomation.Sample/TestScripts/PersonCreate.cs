﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.Dynamics365.UIAutomation.Sample.Extentions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web
{
    [TestClass]
    public class PersonCreate
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();

        [TestMethod]
        public void TestMethod()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                var driver = xrmBrowser.Driver;
                DHCWExtentions.Login(xrmBrowser, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();
                driver.Manage().Window.Maximize();
                xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
                xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                xrmBrowser.ThinkTime(1000);
                driver.SwitchTo().Frame("contentIFrame1");
                IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
                js.ExecuteScript("document.getElementById('ms-crm-Inline-Edit').setAttribute('style','\"display: none;\"')");



                //driver.FindElement(By.XPath("//*[@id=\"firstname_cl\"]")).Click();


                //driver.FindElement(By.Id("firstname_i")).SendKeys("Bobby");
                driver.FindElement(By.XPath("//*[@id=\"lastname_cl\"]")).Click();
                driver.FindElement(By.Name("lastname_i")).SendKeys("TheTester");
                xrmBrowser.ThinkTime(1000);
                driver.FindElement(By.Name("txtDOB")).SendKeys("24/08/1976");
                xrmBrowser.ThinkTime(1000);

                driver.FindElement(By.Name("btnFind")).Click();
                xrmBrowser.ThinkTime(2000);
                xrmBrowser.ThinkTime(2000);
                Actions act = new Actions(driver);

                IWebElement row = driver.FindElement(By.XPath("//*[text()='4073889']"));
                act.DoubleClick(row).Perform();
                xrmBrowser.ThinkTime(5000);
                driver.SwitchTo().Window(driver.WindowHandles.First());
                driver.SwitchTo().Window(driver.WindowHandles[2]);
                driver.SwitchTo().Frame("contentIFrame0");
                driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));
                driver.FindElement(By.XPath("//*[text()='TEST, Billy (WCCIS ID: 4073889)']"));
                driver.FindElement(By.XPath("//*[text()='12/08/1976 (46 Years)']"));
                driver.FindElement(By.XPath("//*[text()='11 GRANGE STREET']"));
                driver.FindElement(By.XPath("//*[text()='PORT TALBOT ']"));
                driver.FindElement(By.XPath("//*[text()='SA13 1EN']"));
                xrmBrowser.ThinkTime(5000);
            }
        }
    }
}