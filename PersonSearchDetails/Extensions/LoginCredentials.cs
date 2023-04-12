using Microsoft.Dynamics365.UIAutomation.Api;
using OpenQA.Selenium;
using System;
using System.Security;
using System.Text;

namespace WCCIS.Specs.Extentions
{
    internal class LoginCredentials
    {

        public static void AdministratorLogin(Browser xrmBrowser, IWebDriver webDriver)
        {
            DHCWExtensions.Login(webDriver, xrmBrowser, "ccis\\ccis_test16", "smpzM2Pe");
        }

        public static void SocialWorkerLogin(Browser xrmBrowser, IWebDriver webDriver)
        {
            DHCWExtensions.Login(webDriver, xrmBrowser, "username", "password");
        }

        public static void CareWorkerLogin(Browser xrmBrowser, IWebDriver webDriver)
        {
            DHCWExtensions.Login(webDriver, xrmBrowser, "username", "password");
        }

    }
}
