using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPINewPatientInvalidNameStepDefinitions
    {
        [When(@"the user conducts an MPI search by NHS number '([^']*)'")]
        public void WhenTheUserConductsAnMPISearchByNHSNumber(string NHSNumber)
        {
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys("test");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(4000);
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.XPath("//*[@id=\"txtNHSNo\"]")).SendKeys(NHSNumber);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(2000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.XPath("//table/tbody/tr/td[@title='" + NHSNumber + "']"));
        }

        [Then(@"on loading the patient, an error message occurs informing the user that the patient name is too long for the record fields")]
        public void ThenOnLoadingThePatientAnErrorMessageOccursInformingTheUserThatThePatientNameIsTooLongForTheRecordFields()
        {
            throw new PendingStepException();
        }

    }
}
