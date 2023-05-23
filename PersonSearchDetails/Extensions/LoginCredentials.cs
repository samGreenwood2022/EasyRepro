using Microsoft.Dynamics365.UIAutomation.Api;
using OpenQA.Selenium;

namespace WCCIS.Specs.Extentions
{
    internal class UserLogin
    {

        public static void AdministratorLogin(Browser xrmBrowser, IWebDriver driver)
        {
            DHCWExtensions.Login(xrmBrowser, driver,"ccis\\ccis_test16", "smpzM2Pe");
        }

        public static void AdultSupportWorkerLogin(Browser xrmBrowser, IWebDriver driver)
        {
            DHCWExtensions.Login(xrmBrowser, driver, "CCIS\\CCIS_Test77", "BJ3hbngK");
        }

        public static void ChildrensSupportWorkerLogin(Browser xrmBrowser, IWebDriver driver)
        {
            DHCWExtensions.Login(xrmBrowser, driver, "CCIS\\CCIS_Test55", "aC7A6\\@}");
        }

    }
}
