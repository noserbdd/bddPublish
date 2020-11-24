using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Driver_AutoTests.Factories
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver()
        {
            ChromeOptions option = new ChromeOptions();
            string binaryLocation = TryFindChromeBinary();
            if (!string.IsNullOrEmpty(binaryLocation))
                option.BinaryLocation = binaryLocation;

            //option.AddArguments("headless");

            return new ChromeDriver(option);
        }

        private string TryFindChromeBinary()
        {
            var fileLocations = new List<string>
            {
                "C:/Program Files/Google/Chrome/Application/chrome.exe",
                "C:/Program Files (x86)/Google/Chrome/Application/chrome.exe"
            };

            foreach (var fileLocation in fileLocations)
            {
                if (File.Exists(fileLocation))
                    return fileLocation;
            }

            return null;
        }
    }
}
