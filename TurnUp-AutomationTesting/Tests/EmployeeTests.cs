using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUp_AutomationTesting.Helpers;
using TurnUp_AutomationTesting.Pages;

namespace TurnUp_AutomationTesting.Tests
{
   [TestFixture]
   [Parallelizable]
    class EmployeeTests: CommonDrivers
    {
        [Test]
        public void CreateTM()
        {
            //Created Navigate object to interact with HomePage class and its methods
            HomePage Navigateobj = new HomePage();
            Navigateobj.NavigateTM(driver);
            TMPage TMFunctionobj = new TMPage();
            TMFunctionobj.CreateNew(driver);
        }

        [Test]
        public void EditTM()
        {
            //Created Navigate object to interact with HomePage class and its methods
            HomePage Navigateobj = new HomePage();
            Navigateobj.NavigateTM(driver); 
            TMPage TMFunctionobj = new TMPage();
            TMFunctionobj.Editexisting(driver);
        }

        [Test]
        public void DeleteTM()
        {
            //Created Navigate object to interact with HomePage class and its methods
            HomePage Navigateobj = new HomePage();
            Navigateobj.NavigateTM(driver); 
            TMPage TMFunctionobj = new TMPage();
            TMFunctionobj.Deleteexisting(driver);
        }

    }
}
