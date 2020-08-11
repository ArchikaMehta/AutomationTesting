using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUp_AutomationTesting.Pages
{
    class LoginPage
    {
        public void Login(IWebDriver driver)
        {
            //Launcing application URL
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

         //Login Flow

            //Maximize window and enter username & password
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("UserName")).SendKeys("hari");
            driver.FindElement(By.Id("Password")).SendKeys("123123");

            //Click login 
            driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();

         //Login Validation

            //Find element to fetch welcome message
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            //Validate welcome message
            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged In successfully, test passed");
            }
            else
            {
                Console.WriteLine("Login failed, test failed");
            }
        }
    }
}
