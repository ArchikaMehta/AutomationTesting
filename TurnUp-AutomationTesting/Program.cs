using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TurnUp_AutomationTesting.Helpers;
using TurnUp_AutomationTesting.Pages;

namespace TurnUp_AutomationTesting
{
    [TestFixture]
    [Parallelizable]
    class Program : CommonDrivers
    {
        HomePage Navigateobj = new HomePage();
        TMPage TMFunctionobj = new TMPage();
        [Test, Order(1), Description("Check if user is able to Login with valid credentials")]
        public void CreateTM()
        {
            //Created Navigate object to interact with HomePage class and its methods
            //HomePage Navigateobj = new HomePage();
            Navigateobj.NavigateTM(driver); 

            //Created TM object to interact with TMPage class and its methods
            //TMPage TMFunctionobj = new TMPage();
            TMFunctionobj.CreateNew(driver);
        }

        [Test, Order(2), Description("Check if user is able to edit the existing record with valid data")]
        public void EditTM()
        {
            //Created Navigate object to interact with HomePage class and its methods
            //HomePage Navigateobj = new HomePage();
           // Navigateobj.NavigateTM(driver);

            //Created TM object to interact with TMPage class and its methods
            //TMPage TMFunctionobj = new TMPage();
            TMFunctionobj.Editexisting(driver);
        }

        [Test, Description("Check if user is able to delete the existing record")]
        public void DeleteTM()
        {
            //Created Navigate object to interact with HomePage class and its methods
           // HomePage Navigateobj = new HomePage();
            //Navigateobj.NavigateTM(driver);

            //Created TM object to interact with TMPage class and its methods
            //TMPage TMFunctionobj = new TMPage();
            TMFunctionobj.Deleteexisting(driver);
        }
    }
}
