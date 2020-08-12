using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUp_AutomationTesting.Pages
{
    class HomePage
    {
        public void NavigateTM(IWebDriver driver)
        {
            try
            {
                //Click dropdown and select Time & material 
                driver.FindElement(By.CssSelector("a.dropdown-toggle")).Click();
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Navigation to Time and Material page is failed", ex.Message);
            }
        }
    }
}
