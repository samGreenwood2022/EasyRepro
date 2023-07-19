using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.PageObjects
{
    internal class Page_MPISearch
    {

        //public

        //Method to click Search
        public static void ClickMPISearch(IWebDriver driver)
        {
            IWebElement MPISearchBtn = LocateMPISearchBtn(driver);
            MPISearchBtn.Click();
        }

        //Method for selecting No in NHS Number radio buttons
        public static void ClickNHSRadioNo(IWebDriver driver)
        {
            IWebElement NHSRadioNo = LocateNHSRadioNo(driver);
            NHSRadioNo.Click();
        }

        //Method for entering text into the First Name text field
        public static void EnterFirstName(IWebDriver driver, string firstName)
        {
            IWebElement textBoxFirstName = LocateTextBoxFirstName(driver);
            textBoxFirstName.SendKeys(firstName);
        }

        //Method for entering text into the Surname text field
        public static void EnterSurname(IWebDriver driver, string surname)
        {
            IWebElement textBoxSurname = LocateTextBoxSurname(driver);
            textBoxSurname.SendKeys(surname);
        }

        //Method for entering text into the Surname text field
        public static void EnterDOB(IWebDriver driver, string dob)
        {
            IWebElement textBoxDOB = LocateTextBoxDOB(driver);
            textBoxDOB.SendKeys(dob);
        }

        //Method for entering text into the NHS number text field
        public static void EnterNHS(IWebDriver driver, string nhs)
        {
            IWebElement textBoxNHS = LocateTextBoxNHS(driver);
            textBoxNHS.SendKeys(nhs);
        }

        //Method for entering text into the Street text field
        public static void EnterStreet(IWebDriver driver, string street)
        {
            IWebElement textBoxStreet = LocateTextBoxStreet(driver);
            textBoxStreet.SendKeys(street);
        }

        //Method for entering text into the Other Designation text field
        public static void EnterOtherDes(IWebDriver driver, string otherDes)
        {
            IWebElement textBoxOtherDes = LocateTextBoxOtherDes(driver);
            textBoxOtherDes.SendKeys(otherDes);
        }

        //Method for entering text into the Town/City text field
        public static void EnterCity(IWebDriver driver, string City)
        {
            IWebElement textBoxCity = LocateTextBoxCity(driver);
            textBoxCity.SendKeys(City);
        }

        //Method for entering text into the County text field
        public static void EnterCounty(IWebDriver driver, string County)
        {
            IWebElement textBoxCounty = LocateTextBoxCounty(driver);
            textBoxCounty.SendKeys(County);
        }

        //Method for entering text into the County text field
        public static void EnterPostCode(IWebDriver driver, string PostCode)
        {
            IWebElement textBoxPostCode = LocateTextBoxPostCode(driver);
            textBoxPostCode.SendKeys(PostCode);
        }

        //Method for entering text into the phone number text field
        public static void EnterPhoneNumber(IWebDriver driver, string PhoneNumber)
        {
            IWebElement textBoxPhoneNumber = LocateTextBoxPhoneNumber(driver);
            textBoxPhoneNumber.SendKeys(PhoneNumber);
        }

        //Method for entering text into the Hospital Number text field
        public static void EnterHospitalNumber(IWebDriver driver, string HospitalNumber)
        {
            IWebElement textBoxHospitalNumber = LocateTextBoxHospitalNo(driver);
            textBoxHospitalNumber.SendKeys(HospitalNumber);
        }

        //Method for clicking into assigning authority field

        public static void SelectAssigningAuth(IWebDriver driver, string AssigningAuth)
        {
            IWebElement fieldAssigningAuth = LocateAssigningAuth(driver);
            fieldAssigningAuth.Click();
            fieldAssigningAuth.FindElement(By.XPath("//*[@value=\"" + AssigningAuth + "\"]")).Click();
        }

        public static String GetErrorMessage(IWebDriver driver)
        {
            string error = driver.FindElement(By.XPath("//*[@id=\"CWNotificationMessage_EMPISearch\"]")).Text;
            return error;
        }

        //private

        //Method for finding MPI Search button

        private static IWebElement LocateMPISearchBtn(IWebDriver driver)
        {
            IWebElement MPISearchBtn = driver.FindElement(By.XPath("//*[@id=\"btnEMPISearch\"]"));
            return MPISearchBtn;
        }

        //Method for finding radio button to select NHS Number as 'No'
        private static IWebElement LocateNHSRadioNo(IWebDriver driver)
        {
            IWebElement radioButtonNHSNo = driver.FindElement(By.XPath("//*[@id=\"NHSNo\"]"));
            return radioButtonNHSNo;
        }

        //Method for finding first name field
        private static IWebElement LocateTextBoxFirstName(IWebDriver driver)
        {
            IWebElement textBoxFirstName = driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]"));
            return textBoxFirstName;
        }

        //Method for finding surname field
        private static IWebElement LocateTextBoxSurname(IWebDriver driver)
        {
            IWebElement textBoxSurname = driver.FindElement(By.XPath("//*[@id=\"txtLastName\"]"));
            return textBoxSurname;
        }

        //Method for finding NHS number field
        private static IWebElement LocateTextBoxNHS(IWebDriver driver)
        {
            IWebElement textBoxNHS = driver.FindElement(By.XPath("//*[@id=\"txtNHSNo\"]"));
            return textBoxNHS;
        }

        //Method for finding DOB field
        private static IWebElement LocateTextBoxDOB(IWebDriver driver)
        {
            IWebElement textBoxDOB = driver.FindElement(By.XPath("//*[@id=\"txtDOB\"]"));
            return textBoxDOB;
        }

        //Method for finding Street field
        private static IWebElement LocateTextBoxStreet(IWebDriver driver)
        {
            IWebElement textBoxStreet = driver.FindElement(By.XPath("//*[@id=\"txtStreetAddress\"]"));
            return textBoxStreet;
        }

        //Method for finding Other Designation field
        private static IWebElement LocateTextBoxOtherDes(IWebDriver driver)
        {
            IWebElement textBoxOtherDes = driver.FindElement(By.XPath("//*[@id=\"txtOtherDesignation\"]"));
            return textBoxOtherDes;
        }

        //Method for finding Town/City field
        private static IWebElement LocateTextBoxCity(IWebDriver driver)
        {
            IWebElement textBoxCity = driver.FindElement(By.XPath("//*[@id=\"txtCity\"]"));
            return textBoxCity;
        }

        //Method for finding County field
        private static IWebElement LocateTextBoxCounty(IWebDriver driver)
        {
            IWebElement textBoxCounty = driver.FindElement(By.XPath("//*[@id=\"txtStateOrProvince\"]"));
            return textBoxCounty;
        }

        //Method for finding Post Code field
        private static IWebElement LocateTextBoxPostCode(IWebDriver driver)
        {
            IWebElement textBoxPostCode = driver.FindElement(By.XPath("//*[@id=\"txtPostCode\"]"));
            return textBoxPostCode;
        }

        //Method for finding phone number field
        private static IWebElement LocateTextBoxPhoneNumber(IWebDriver driver)
        {
            IWebElement textBoxPhoneNumber = driver.FindElement(By.XPath("//*[@id=\"txtPhone\"]"));
            return textBoxPhoneNumber;
        }


        //Method for finding hospital number field
        private static IWebElement LocateTextBoxHospitalNo(IWebDriver driver)
        {
            IWebElement textBoxHospitalNo = driver.FindElement(By.XPath("//*[@id=\"txtSourceID\"]"));
            return textBoxHospitalNo;
        }

        //Method for finding assigning authority field
        private static IWebElement LocateAssigningAuth(IWebDriver driver)
        {
            IWebElement dropDownAssigningAuth = driver.FindElement(By.XPath("//*[@id=\"ddlSourceCode\"]"));
            return dropDownAssigningAuth;
        }


    }
}
