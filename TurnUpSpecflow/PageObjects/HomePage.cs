using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUpSpecflow.PageObjects
{
    internal class HomePage : LoginPage
    {
        //Created constructor for dependency injection
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        internal void NavigateTM()
        {
            try
            {
                //Click dropdown and selecting Time from Time & material option
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
            //Validating if Create new button is available on the page or not
            IWebElement createnew = _driver.FindElement(By.CssSelector("a.btn.btn-primary"));

            Assert.IsTrue(createnew.Text.Contains("Create New"));
        }
    }
}
