﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using TurnUp_AutomationTesting.Helpers;

namespace TurnUp_AutomationTesting.Pages
{
    class TMPage
    {
        String des;
        //Declare and initialize a local variable for passing it as row index in XPath to select the created record for editing
        int index = 999;

        public void CreateNew(IWebDriver driver)
        {
         //Creation of new time or material record

            try
            { 
            //Click on create new button
            driver.FindElement(By.CssSelector("a.btn.btn-primary")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to navigate to Create new Time and Material page", ex.Message);
            }

            try 
            { 
            //Click on dropdown
            driver.FindElement(By.CssSelector("span.k-icon.k-i-arrow-s")).Click();

            //Wait for dropdown to load values
            WaitHelpersTurnUp.WaitClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 3);

            //Seleting TypeCode time from dropdown
            driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();

            //Entering data (code, description and price per unit) for new time record creation
            driver.FindElement(By.CssSelector("input#Code.text-box.single-line")).SendKeys("Aug");

            //Generate unique description using current timestamp
            des = (DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            driver.FindElement(By.CssSelector("input#Description.text-box.single-line")).SendKeys(des);

            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys("2020");
            //driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            //driver.FindElement(By.Id("Price")).SendKeys("2020");
            //price.Click();
            //IWebElement price1 = driver.FindElement(By.Id("Price"));
            //price1.SendKeys("2020");

            //File upload
            driver.FindElement(By.Id("files")).SendKeys(@"C:\Users\ceeka\Desktop\test.txt");

            //Save the record
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("New record creation page did not load successfully", ex.Message);
            }

            //Wait for last page button to get enabled
            WaitHelpersTurnUp.WaitClickable(driver, "CssSelector", "span.k-icon.k-i-seek-e", 15);

            //Validation of create new time or material record

            //Click on button to go to the last page
            driver.FindElement(By.CssSelector("span.k-icon.k-i-seek-e")).Click();
            driver.FindElement(By.CssSelector("span.k-icon.k-i-seek-e")).Click();

            //Create a collection of elements of description column
            IReadOnlyCollection<IWebElement> colDescriptions = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[3]"));

            //Iterating over the collection to fetch the description one by one from the rows on page
            for (int i = 0; i < colDescriptions.Count; i++)
            {
                //Read the text value of element and save it in a string
                string colData = colDescriptions.ElementAt(i).Text;

                //Comparing coloum data with the entered data for validation
                if (colData == des)
                {
                    //Assigning the location of element where enetered data found to the variable. This will be used in edit test case
                    index = i + 1;
                           
                    Assert.Pass("New record created sucessfully, test passed");

                    //Breaking the loop when enetered data is found
                    break;
                }
                else if ((i + 1) >= colDescriptions.Count)
                {
                    Assert.Fail("New record creation failed, test failed");
                }
            }          
        }

        public void Editexisting(IWebDriver driver)
        {
            //Editing the already created record

            //Wait for last page button to get enabled
            WaitHelpersTurnUp.WaitClickable(driver, "CssSelector", "span.k-icon.k-i-seek-e", 15);

            try
            { 
                //Click on button to go to the last page
                driver.FindElement(By.CssSelector("span.k-icon.k-i-seek-e")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on the last page button", ex.Message);
            }

            try
            {
                WaitHelpersTurnUp.WaitClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[5]/a[1]", 15);

                //Click on edit button
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[5]/a[1]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on the edit button", ex.Message);
            }
                        
            //New price 
            String editprice = ("2050");

            try
            {
                //Click on price field to enable it
                driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();

                //Clear the contents of price field
                driver.FindElement(By.Id("Price")).Clear();

                //Enter new price
                driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys(editprice);

                //Save the record with edited price
                driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Edit record page did not load successfully", ex.Message);
            }

            //Wait for last page button to get enabled
            WaitHelpersTurnUp.WaitClickable(driver, "CssSelector", "span.k-icon.k-i-seek-e", 15);

            //Validate Edited record

            //Click on button to go to the last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();

            //Create a collection of elements of description column
            IReadOnlyCollection<IWebElement> colDescriptionsedit = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[3]"));

            //Iterating over the collection to fetch the description one by one from the rows on page
            for (int j = 0; j < colDescriptionsedit.Count; j++)
            {
                //Read the text value of element and save it in a string
                string colDataedit = colDescriptionsedit.ElementAt(j).Text;

                //Comparing coloum data with the entered data for validation
                if (colDataedit == des)
                {
                    //Assigning the location of element where enetered data found, to the variable
                    int indexedit = j + 1;

                    //Read the text value of element and save it in a string
                    String pricedited = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + indexedit + "]/td[4]")).Text;
                    
                    //Replace "," with null value for matching the syntax of price entered
                    pricedited = pricedited.Replace(",", "");

                    //Applying assertion to validate the price is edited or not
                    if (pricedited.Contains(editprice))
                    {
                        Assert.Pass("Record edited successfully, test passed");
                    }
                    else
                    {
                        Assert.Fail("Record edit failed, test failed");
                    }
                }
            }
        }

        public void Deleteexisting(IWebDriver driver)
        {
            //Testing the delete record functionality

            //Wait for last page button to get enabled
            WaitHelpersTurnUp.WaitClickable(driver, "CssSelector", "span.k-icon.k-i-seek-e", 5);

            try
            {
                //Click on button to go to the last page
                driver.FindElement(By.CssSelector("span.k-icon.k-i-seek-e")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on the last page button", ex.Message);
            }

            try
            {
                WaitHelpersTurnUp.WaitClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[5]/a[2]", 15);

                //Click on delete button for the edited record
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + index + "]/td[5]/a[2]")).Click();

                //Click Ok on alert message to confirm deletion
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to delete record", ex.Message);
            }

            //Wait for page to reload
            Thread.Sleep(2000);

            //Validating record deletion

            //Create a collection of elements of description column
            IReadOnlyCollection <IWebElement> colDescriptionsdelete = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[3]"));

            //Iterating over the collection to fetch the description one by one from the rows on page
            for (int k = 0; k < colDescriptionsdelete.Count; k++)
            {   
                //Read the text value of element and save it in a string
                string colDatadelete = colDescriptionsdelete.ElementAt(k).Text;

                //Comparing coloum data with the entered data for validation
                if (colDatadelete == des)
                {
                    Assert.Fail("Record deletion failed, test failed");
                }

                else if ((k + 1) >= colDescriptionsdelete.Count())
                {
                    Assert.Pass("Record deleted sucessfully, test passed");
                }
            }
        }
    }
}
