using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUpSpecflow.PageObjects
{
    public abstract class BasePage
    {
        public readonly IWebDriver _driver;

        //Created constructor for dependency injection
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Navigating to given URL
        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

    //Implementing Explicit wait

        public static void WaitClickable(IWebDriver driver, String attribute, String value, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (attribute == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.Id(value))));
            }
            else if (attribute == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(value)));
            }
            else if (attribute == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(value)));
            }
        }
    }
}
