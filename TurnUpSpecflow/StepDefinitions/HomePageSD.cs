using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TurnUpSpecflow.PageObjects;

namespace TurnUpSpecflow.StepDefinitions
{
    [Binding]
    public sealed class HomePageSD
    {
        //Created an object to access the functions of different classes
        private HomePage homePage;

        //Created constructor for dependency injection
        public HomePageSD(IWebDriver driver)
        {
            homePage = new HomePage(driver);
        }

        [Given(@"I am on Home page")]
        public void GivenIAmOnHomePage()
        {
            homePage.ValidateLogin();
        }

        [When(@"I click option ""(.*)"" under Administration Drop Down on the Main Page")]
        public void WhenIClickOptionUnderAdministrationDropDownOnTheMainPage(string p0)
        {
            homePage.NavigateTM();          
        }

        [Then(@"I verify that I am navigated to TM Page")]
        public void ThenIVerifyThatIAmNavigatedToTMPage()
        {
            homePage.ValidateTM();
        }
    }
}
