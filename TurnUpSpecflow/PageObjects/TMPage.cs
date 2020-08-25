using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TurnUpSpecflow.PageObjects
{
    internal class TMPage : HomePage
    {
        public TMPage(IWebDriver driver) : base(driver)
        {

        }

        String des;
        //Declare and initialize a local variable for passing it as row index in XPath to select the created record for editing
        int index = 999;

        internal void CreateNew()
        {
            //Creation of new time or material record

            
                //Click on create new button
                _driver.FindElement(By.CssSelector("a.btn.btn-primary")).Click();
            
        }

        internal void DropDown()
        {
            
                //Click on dropdown
                _driver.FindElement(By.CssSelector("span.k-icon.k-i-arrow-s")).Click();

                //Wait for dropdown to load values
                Thread.Sleep(2000);
            
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
                //_driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
                //_driver.FindElement(By.Id("Price")).SendKeys("2020");
                //price.Click();
                //IWebElement price1 = _driver.FindElement(By.Id("Price"));
                //price1.SendKeys("2020");

                //File upload
                //_driver.FindElement(By.Id("files")).SendKeys(@"C:\Users\ceeka\Desktop\test.txt");

                //Save the record
                _driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();
            
        }

        internal void ValidateCreateNew()
        {
                //Validation of create new time or material record
                //Wait for last page button to get enabled
                Thread.Sleep(3000);

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
                        //Assigning the location of element where enetered data found to the variable. This will be used in edit test case
                        index = i + 1;

                        //Assert.Pass("New record created sucessfully, test passed");
                        Assert.IsTrue(colData == des);

                        //Breaking the loop when enetered data is found
                        break;
                    }
                    else if ((i + 1) >= colDescriptions.Count)
                    {
                        Assert.Fail("New record creation failed, test failed");
                    }
                }
            }
    }
}
