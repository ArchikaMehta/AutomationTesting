using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUpSpecflow.PageObjects
{
    internal class HomePage : LoginPage
    {
        // private IWebDriver driver;
        public HomePage(IWebDriver driver) : base(driver)
        {

        }


        internal void NavigateTM()
        {
            try
            {
                //Click dropdown and select Time & material 
                _driver.FindElement(By.CssSelector("a.dropdown-toggle")).Click();
                _driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Navigation to Time and Material page is failed", ex.Message);
            }
        }

        internal void ValidateTM()
        {
            IWebElement createnew = _driver.FindElement(By.CssSelector("a.btn.btn-primary"));

            Assert.IsTrue(createnew.Text.Contains("Create New"));
        }
    }
}
