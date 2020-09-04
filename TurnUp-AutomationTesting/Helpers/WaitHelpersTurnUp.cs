using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace TurnUp_AutomationTesting.Helpers
{
    class WaitHelpersTurnUp
    {
        public static void WaitClickable(IWebDriver driver, String attribute, String value, int seconds)
        { 
            if (attribute =="Id")
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable((By.Id(value))));
            }
            else if (attribute == "XPath")
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(value)));
            }
            else if (attribute == "CssSelector")
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(value)));
            }
        }
    }
}
