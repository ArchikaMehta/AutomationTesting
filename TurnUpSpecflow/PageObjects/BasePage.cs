using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUpSpecflow.PageObjects
{
    public abstract class BasePage
    {
        public readonly IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Used for Navigation to different pages
        // Website Url Example : www.google.com 
        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
