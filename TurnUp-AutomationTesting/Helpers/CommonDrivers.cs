using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUp_AutomationTesting.Pages;

namespace TurnUp_AutomationTesting.Helpers
{
    class CommonDrivers
    {
        // Defining Web driver element
        public IWebDriver driver;

        [OneTimeSetUp]
        public void LoginAction()
        {
            //Initiating Web driver element
            driver = new ChromeDriver("C:\\Study\\Automation\\chromedriver_win32");
            
            //Created Login object to interact with LoginPage class and its methods
            LoginPage Loginobj = new LoginPage();
            Loginobj.Login(driver);
        }
            
        [OneTimeTearDown]
        public void ClosingSteps()
        {
            //Closing all the opened browser instances
            driver.Quit();
        }


        }
    }