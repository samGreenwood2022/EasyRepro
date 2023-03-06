// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;

namespace Microsoft.Dynamics365.UIAutomation.Sample
{
    public static class TestSettings
    {
        public static string InvalidAccountLogicalName = "accounts";

        public static string LookupField = "primarycontactid";
        public static string LookupName = "Rene Valdes (sample)";
        private static readonly string Type = System.Configuration.ConfigurationManager.AppSettings["BrowserType"].ToString();

        public static BrowserOptions Options = new BrowserOptions
        {
            BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), Type),
            PrivateMode = false,
            FireEvents = false,
            Headless = false,
            UserAgent = false,
            //DriversPath = @"""C:\Users\sa286848\Documents\RedCortex\EasyRepro\Microsoft.Dynamics365.UIAutomation.Sample\chromedriver\chromedriver.exe"""
        };
    }
}
