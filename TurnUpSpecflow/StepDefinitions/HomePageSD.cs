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
        private HomePage homePage;
        
        public HomePageSD(IWebDriver driver)
        {
            homePage = new HomePage(driver);
        }

        [Given(@"User is on Home page")]
        public void GivenUserIsOnHomePage()
        {
            homePage.ValidateLogin();
        }


        [When(@"I click option ""(.*)"" under Administration Drop Down on the Main Page")]
        public void WhenIClickOptionUnderAdministrationDropDownOnTheMainPage(string p0)
        {
            homePage.NavigateTM();
            
        }

        [Then(@"I verify I navigated to TM Page")]
        public void ThenIVerifyINavigatedToTMPage()
        {
            homePage.ValidateTM();
        }

    }
}
