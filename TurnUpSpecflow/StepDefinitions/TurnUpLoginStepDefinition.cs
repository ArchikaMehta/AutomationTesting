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
    public sealed class TurnUpLoginStepDefinition
    {
        private LoginPage loginPage;

        public TurnUpLoginStepDefinition(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);

        }
        [Given(@"I navigate to the TurnUp Portal")]
        public void GivenINavigateToTheTurnUpPortal()
        {
            var url = "http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f";

            loginPage.Navigate(url);


        }

        [When(@"I login to the TurnUp Portal")]
        public void WhenILoginToTheTurnUpPortal()
        {
            loginPage.Login();


        }

        [Then(@"I verify I am on the TurnUp Portal")]
        public void ThenIVerifyIAmOnTheTurnUpPortal()
        {
            loginPage.ValidateLogin();
        }

    }
}
