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

        public static void AdultSupportWorkerLogin(Browser xrmBrowser, IWebDriver webDriver)
        {
            DHCWExtensions.Login(webDriver, xrmBrowser, "CCIS\\CCIS_Test77", "BJ3hbngK");
        }

        public static void ChildrensSupportWorkerLogin(Browser xrmBrowser, IWebDriver webDriver)
        {
            DHCWExtensions.Login(webDriver, xrmBrowser, "CCIS\\CCIS_Test55", "aC7A6\\@}");
        }

    }
}
