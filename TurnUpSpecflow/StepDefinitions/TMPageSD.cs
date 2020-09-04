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
        //Created an object to access the functions of different classes
        private TMPage tmPageObj;

        //Created constructor for dependency injection
        public TMPageSD(IWebDriver driver)
        {
            tmPageObj = new TMPage(driver);
        }

        [Given(@"I am on ""(.*)"" page")]
        public void GivenIAmOnPage(string p0)
        {
            tmPageObj.ValidateTM();
        }

        [When(@"I click on Create New button")]
        public void WhenIClickedOnCreateNewButton()
        {
            tmPageObj.CreateNew();
        }

        [When(@"I click on the drop down option in TypeCode field")]
        public void WhenIClickedOnTheDropDownOptionInTypeCodeField()
        {
            tmPageObj.DropDown();
        }

        [When(@"I select ""(.*)"" from time and material options")]
        public void WhenISelectedFromTimeAndMaterialOptions(string p0)
        {
            tmPageObj.TypeCode();
        }

        [When(@"I enter the valid data \(code, description and price per unit\) and clicked on save button")]
        public void WhenIEnterTheValidDataCodeDescriptionAndPricePerUnitAndClickedOnSaveButton()
        {
            tmPageObj.RecordData();
        }

        [Then(@"I verify a new record has created successfully")]
        public void ThenIVerifyANewRecordHasCreatedSuccessfully()
        {
            tmPageObj.ValidateCreateNew();
        }

        [When(@"I click on the last page button")]
        public void WhenIclickOnTheLastPageButton()
        {
            tmPageObj.LastPage();
        }

        [When(@"I search for unique record to ""(.*)""")]
        public void WhenISearchForUniqueRecordTo(string p0)
        {
            tmPageObj.UniqueRecordSearch();
        }

        [When(@"I edit the record ""(.*)""")]
        public void WhenIEditTheRecord(string p0)
        {
            tmPageObj.EditExisting();
        }

        [When(@"I save the recrod")]
        public void WhenISaveTheRecrod()
        {
            tmPageObj.SaveEdit();
        }

        [Then(@"I verify that an existing record has edited successfully")]
        public void ThenIVerifyThatAnExistingRecordHasEditedSuccessfully()
        {
            tmPageObj.ValidateEdit();
        }

        [When(@"I delete the record")]
        public void WhenIDeleteTheRecord()
        {
            tmPageObj.Deleteexisting();
        }

        [Then(@"I verify that an existing record has deleted successfully")]
        public void ThenIVerifyThatAnExistingRecordHasDeletedSuccessfully()
        {
            tmPageObj.ValidateDelete();
        }
    }
}
