using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TurnUp_AutomationTesting.Pages;

namespace TurnUp_AutomationTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Launching web driver
            IWebDriver driver = new ChromeDriver("C:\\Study\\Automation\\chromedriver_win32");

            //Created Login object to interact with LoginPage class and its methods
            LoginPage Loginobj = new LoginPage();
            Loginobj.Login(driver);

            //Created Navigate object to interact with HomePage class and its methods
            HomePage Navigateobj = new HomePage();
            Navigateobj.NavigateTM(driver);

            //Created TM object to interact with TMPage class and its methods
            TMPage TMFunctionobj = new TMPage();
            TMFunctionobj.CreateNew(driver);
            TMFunctionobj.Editexisting(driver);
            TMFunctionobj.Deleteexisting(driver);
        }
    }
}
