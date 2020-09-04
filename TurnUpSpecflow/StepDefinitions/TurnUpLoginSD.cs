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
    public sealed class TurnUpLoginSD
    {
        //Created an object to access the functions of different classes
        private LoginPage loginPage;

        //Created constructor for dependency injection
        public TurnUpLoginSD(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
        }

        [Given(@"I navigated to the TurnUp Portal")]
        public void GivenINavigatedToTheTurnUpPortal()
        {
            var url = "https://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f";
            loginPage.Navigate(url);
        }

        [When(@"I login to the TurnUp Portal")]
        public void WhenILoginToTheTurnUpPortal()
        {
            loginPage.Login();
        }

        [Then(@"I verify that I am on the TurnUp Portal")]
        public void ThenIVerifyThatIAmOnTheTurnUpPortal()
        {
            loginPage.ValidateLogin();
        }
    }
}
