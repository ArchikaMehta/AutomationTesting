using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUpSpecflow.PageObjects
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        internal void Login()
        {
            try
            {
             //Login Flow

                //Enter username & password
                _driver.FindElement(By.Id("UserName")).SendKeys("hari");
                _driver.FindElement(By.Id("Password")).SendKeys("123123");

                //Click login 
                _driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Login page did not load successfully and user is unable to login", ex.Message);
            }
        }

        internal void ValidateLogin()
        {
            //Login Validation

            //Find element to fetch welcome message
            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement helloHari = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='logoutForm']/ul/li/a")));


           // IWebElement helloHari = _driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            Assert.IsTrue(helloHari.Text.Contains("Hello hari"));
        }
    }
}
