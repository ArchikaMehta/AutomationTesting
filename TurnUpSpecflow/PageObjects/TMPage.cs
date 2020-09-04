using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;


namespace TurnUpSpecflow.PageObjects
{
    internal class TMPage : HomePage
    {
        //Created constructor for dependency injection
        public TMPage(IWebDriver driver) : base(driver)
        {

        }

        //Declaring variables used in various functions
        String des;
        int index = 999;
        String editprice = ("2050");
        String BeforeDelete;

    //Creation of new time or material record

        internal void CreateNew()
        {
            //Click on create new button
            _driver.FindElement(By.CssSelector("a.btn.btn-primary")).Click();
        }

        internal void DropDown()
        {
             //Click on dropdown
            _driver.FindElement(By.CssSelector("span.k-icon.k-i-arrow-s")).Click();
        }

        internal void TypeCode()
        {
            //Seleting TypeCode time from dropdown
            _driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();
        }

        internal void RecordData()
        {
            //Entering data (code, description and price per unit) for new time record creation
            _driver.FindElement(By.CssSelector("input#Code.text-box.single-line")).SendKeys("Aug");

            //Generate unique description using current timestamp
            des = (DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            _driver.FindElement(By.CssSelector("input#Description.text-box.single-line")).SendKeys(des);

            _driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys("2020");
            
            //File upload
            //_driver.FindElement(By.Id("files")).SendKeys(@"C:\Users\ceeka\Desktop\test.txt");

            //Save the record
            _driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();
        }

    //Validation of create new time or material record

        internal void ValidateCreateNew()
        {
            //Wait for last page button to get enabled
            WaitClickable(_driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]", 15); ;

            try
            {
                //Click on button to go to the last page
                _driver.FindElement(By.CssSelector("a.k-link.k-pager-nav.k-pager-last")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on the last page button", ex.Message);
            }

            //Click on button to go to the last page
            _driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();

            //Create a collection of elements of description column
            IReadOnlyCollection<IWebElement> colDescriptions = _driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[3]"));

            //Iterating over the collection to fetch the description one by one from the rows on page
            for (int i = 0; i < colDescriptions.Count; i++)
            {
                //Read the text value of element and save it in a string
                string colData = colDescriptions.ElementAt(i).Text;

                //Comparing coloum data with the entered data for validation
                if (colData == des)
                {
                    //Assigning the location of element where enetered data found to the variable
                    index = i + 1;

                    Assert.IsTrue(colData == des);

                    //Breaking the loop when enetered data is found
                    break;
                }
                else if ((i + 1) >= colDescriptions.Count)
                {
                    Assert.Fail("New record creation failed, test failed.");
                }
            }
        }

    //Editing the existing time or material record

        internal void LastPage()
        {
            //Wait for last page button to get enabled
            WaitClickable(_driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]", 15);

            try
            {
                //Click on button to go to the last page
                _driver.FindElement(By.CssSelector("a.k-link.k-pager-nav.k-pager-last")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on the last page button", ex.Message);
            }
        }

        internal void UniqueRecordSearch()
        {
            //Create a collection of elements of description column
            IReadOnlyCollection<IWebElement> colDescriptionsedit = _driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[3]"));

            //Finding a unique record using regular expression
            Regex rgx = new Regex(@"^\d{17}");

            //Iterating over the collection to fetch the description one by one from the rows on page

            for (int j = 0; j < colDescriptionsedit.Count; j++)
            {
                //Read the text value of element and save it in a string
                string colDataedit = colDescriptionsedit.ElementAt(j).Text;

                //Comparing the regular expression to collection of description column data 
                if (rgx.IsMatch(colDataedit))
                {
                    //Assigning the location of element where unique data found, to the variable
                    index = (j + 1);
                    //Breaking the loop when unique data is found
                    break;
                }
                else if ((j + 1) >= colDescriptionsedit.Count())
                {
                    Assert.Fail("No unique data found in the table");
                }
            }
        }

        internal void EditExisting()
        {
            try
            {
                //Click on edit button
                _driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[5]/a[1]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on the edit button", ex.Message);
            }
            try
            {
                //Click on price field to enable it
                _driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();

                //Clear the contents of price field
                _driver.FindElement(By.Id("Price")).Clear();

                //Enter new price
                _driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys(editprice);
            }
            catch (Exception ex)
            {
                Assert.Fail("Edit record page did not load successfully", ex.Message);
            }
        }

        internal void SaveEdit()
        {
            try
            {
                //Save the record with edited price
                _driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Edit record page did not load successfully", ex.Message);
            }
        }

    //Validation of editing in existing time or material record

        internal void ValidateEdit()
        {

            //Wait for last page button to get enabled
            WaitClickable(_driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]", 15);

            try
            {
                //Click on button to go to the last page
                _driver.FindElement(By.CssSelector("a.k-link.k-pager-nav.k-pager-last")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on the last page button", ex.Message);
            }

            //Read the text value of element and save it in a string
            String pricedited = _driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[4]")).Text;

            //Replace "," with null value for matching the syntax of price entered
            pricedited = pricedited.Replace(",", "");

            //Applying assertion to validate the price is edited or not
            Assert.IsTrue(pricedited.Contains(editprice));
        }

    //Deletion of the existing time or material record

        internal void Deleteexisting()
        {
            //Read the text value of unique record found and save it in a string
            BeforeDelete = _driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[3]")).Text;

            try
            {
                //Click on delete button for the unique record
                _driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[5]/a[2]")).Click();

                //Click Ok on alert message to confirm deletion
                _driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to delete record", ex.Message);
            }
        }

    //Validation of deletion of an existing time or material record

        internal void ValidateDelete()
        {
            //Wait for page to reload
            Thread.Sleep(2000);

            //Declaring and initializing a boolean variable 
            Boolean isDeleted=false;

            //Validating record deletion

            try
            {
                //Validainge if any element is avilable on unique record index or not
                isDeleted = _driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[3]")).Displayed;

                //Read the text value of unique record index element and save it in a string for comparison
                String AfterDelete = _driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[3]")).Text;

                Assert.IsTrue(BeforeDelete != AfterDelete);
            }
            catch (NoSuchElementException ex)
            {
                Assert.IsTrue(!isDeleted);
            }
        }
    }
}
