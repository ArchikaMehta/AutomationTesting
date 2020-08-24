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
    public sealed class TMPageSD
    {
        private TMPage tmPageObj;

        public TMPageSD(IWebDriver driver)
        {
            tmPageObj = new TMPage(driver);
        }
        [Given(@"I am on ""(.*)"" page")]
        public void GivenIAmOnPage(string p0)
        {
            tmPageObj.ValidateTM();
        }

        [When(@"I clicked on Create New button")]
        public void WhenIClickedOnCreateNewButton()
        {
            tmPageObj.CreateNew();
        }

        [When(@"I clicked on the drop down option in TypeCode field")]
        public void WhenIClickedOnTheDropDownOptionInTypeCodeField()
        {
            tmPageObj.DropDown();
        }

        [When(@"I selected ""(.*)"" from time and material options")]
        public void WhenISelectedFromTimeAndMaterialOptions(string p0)
        {
            tmPageObj.TypeCode();
        }

        [When(@"I entered the valid data \(code, description and price per unit\) and clicked on save button")]
        public void WhenIEnteredTheValidDataCodeDescriptionAndPricePerUnitAndClickedOnSaveButton()
        {
            tmPageObj.RecordData();
        }

        [Then(@"I varifies a new record has created successfully")]
        public void ThenIVarifiesANewRecordHasCreatedSuccessfully()
        {
            tmPageObj.ValidateCreateNew();
        }

    }
}
