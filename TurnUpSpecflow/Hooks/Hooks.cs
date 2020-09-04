using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace TurnUpSpecflow.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver _driver;

        //IOC container using for dependency injection

        private readonly IObjectContainer _objectContainer;

        //Constructor created for dependency injection
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            GetDriver();
        }

        private IWebDriver GetDriver()
        {
            var browser = "Chrome";

            if (_driver == null)
            {
                switch (browser)
                {                    
                    case "Chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();

                        var headless = "false";

                        if (headless == "true")
                        {
                            chromeOptions.AddArgument("--headless");
                        }

                        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
                        break;
                }

                try
                {
                    //Defining implicit wait to the browser
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                    //Deleting all the cookies
                    _driver.Manage().Cookies.DeleteAllCookies();

                    //Maximizing the windows
                    _driver.Manage().Window.Maximize();

                    //Registering the driver to container
                    _objectContainer.RegisterInstanceAs(_driver);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message + " Driver failed to initialize");
                }
            }

            return _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Closing the browser
            _driver.Close();

            //Deallocating the memory used by the browser and objects
            _driver.Dispose();
        }
    }
}
