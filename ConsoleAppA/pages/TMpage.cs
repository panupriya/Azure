using NUnit.Framework;
using OpenQA.Selenium;
using September2020.helpers;
using System;
using System.Net.WebSockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace September2020.pages
{
    class TMpage
    {
        /// <summary>
        /// This will return random code Example: code123
        /// </summary>
        /// <returns></returns>
     
        public string CreateRandomCode()
        {
            var r = new Random();
            return "code" + r.Next(1, 999);           
        }
        
        public void CreateTM(IWebDriver driver)
        {
            //click createnew time and material
            IWebElement createnew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnew.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 5);

            //click typecode dropdown list
            IWebElement time = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span"));
            time.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 5);

            // select time
            IWebElement typecode = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            typecode.Click();

            wait.WaitForElement(driver, "Id", "Code", 5);

            //input code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("Sep2020");


            //input discription
            IWebElement discription = driver.FindElement(By.Id("Description"));
            discription.SendKeys("Test_time");

            //price is overriding so call the first input then call price input
            IWebElement price = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            price.Click();

            IWebElement pricePerUnit = driver.FindElement(By.Id("Price"));
            pricePerUnit.SendKeys("5000");

            wait.WaitForElementVisibility(driver, "XPath", "//*[@id='SaveButton']", 400);

            // select file

            // save data
            IWebElement savebutton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            savebutton.Click();

            //wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 5000);
            Thread.Sleep(5000);
            try
            {
                //goto last page
                IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
                lastpage.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("last page cannot be loaded", ex.Message);
            }
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 400);
            //last test element selection
            IWebElement expectedcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (expectedcode.Text == "Sep2020")
            {
                //using Aseert pass and fail on if condition
                Assert.Pass("Time page created succesfully");

            }
            else
            {
                Assert.Fail("time page created failed");

            }


        }
        

       

        

        //Creating multiple TM
        internal void CreateTMWithValues(IWebDriver driver, string codeName, string desc)
        {
            
            //click createnew time and material
            IWebElement createnew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnew.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 5);

            //click typecode dropdown list
            IWebElement time = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span"));
            time.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 5);

            // select time
            IWebElement typecode = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            typecode.Click();

            wait.WaitForElement(driver, "Id", "Code", 5);

            //input code
            IWebElement code = driver.FindElement(By.Id("Code"));
            // code from feature file
            code.SendKeys(codeName);

            //input discription
            IWebElement discription = driver.FindElement(By.Id("Description"));
            //get from feature file
            discription.SendKeys(desc);

            //price is overriding so call the first input then call price input
            IWebElement price = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            price.Click();

            IWebElement pricePerUnit = driver.FindElement(By.Id("Price"));
            pricePerUnit.SendKeys("5000");

            wait.WaitForElementVisibility(driver, "XPath", "//*[@id='SaveButton']", 400);

            // select file

            // save data
            IWebElement savebutton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            savebutton.Click();

           
        }

     


        //verify multiple TM creation
        internal bool IsRecordCreated(IWebDriver driver, string code)
        {
            Thread.Sleep(5000);
            try
            {
                //goto last page
                IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
                lastpage.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("last page cannot be loaded", ex.Message);
            }
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 400);

            //last test element selection
            IWebElement expectedcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (expectedcode.Text == code)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        //EditTM
        public void EditTM(IWebDriver driver)
        {
            Thread.Sleep(5000);
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 400);
            //goto laste page
            IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastpage.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 10);

            //data to edit button
            IWebElement editcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            editcode.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 20);

            //edit button
            IWebElement editbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editbutton.Click();
            wait.WaitForElement(driver, "Id", "Code", 20);

            //update code
            IWebElement editCode = driver.FindElement(By.Id("Code"));
            editCode.Clear();
            editCode.SendKeys("Sep2020 updated");
            wait.WaitForElementVisibility(driver, "id", "Description", 10);

            //update discription
            IWebElement editDiscription = driver.FindElement(By.Id("Description"));
            editDiscription.Clear();
            editDiscription.SendKeys("Test_time updated");

            wait.WaitForElement(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 20);

            //price is overriding so call the first input then call price input
            IWebElement editPrice = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            editPrice.Click();

            wait.WaitForElementVisibility(driver, "id", "price", 20);
            // update price
            IWebElement editPricePerUnit = driver.FindElement(By.Id("Price"));
            editPricePerUnit.Clear();

            wait.WaitForElement(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 100);

            IWebElement editPrice1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            editPrice1.Click();

            wait.WaitForElementVisibility(driver, "id", "price", 20);
            IWebElement editPricePerUnit1 = driver.FindElement(By.Id("Price"));
            editPricePerUnit1.SendKeys("10000");

            wait.WaitForElementVisibility(driver, "XPath", "//*[@id='SaveButton']", 60);

            // select file



            // save edited data
            IWebElement editSavebutton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            editSavebutton.Click();


            // wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 500);
            Thread.Sleep(5000);
            //goto last page
            IWebElement editLastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            editLastpage.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 100);
            //edited last test element selection
            IWebElement editedcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //-- another method assertion
            Assert.That(editedcode.Text, Is.EqualTo("Sep2020 updated"));

        }

        //edit with random values
        internal static void CreateEditWithValues(IWebDriver driver, string editCode, string editDesc)
        {
            Thread.Sleep(5000);
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 400);
            //goto laste page
            IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastpage.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 10);

            //data to edit button
            IWebElement editcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            editcode.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 20);

            //edit button
            IWebElement editbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editbutton.Click();
            wait.WaitForElement(driver, "Id", "Code", 20);

            //update code
            IWebElement edCode = driver.FindElement(By.Id("Code"));
            edCode.Clear();
            edCode.SendKeys(editCode);
            wait.WaitForElementVisibility(driver, "id", "Description", 10);

            //update discription
            IWebElement editDiscription = driver.FindElement(By.Id("Description"));
            editDiscription.Clear();
            editDiscription.SendKeys(editDesc);

            wait.WaitForElement(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 20);

            //price is overriding so call the first input then call price input
            IWebElement editPrice = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            editPrice.Click();

            wait.WaitForElementVisibility(driver, "id", "price", 20);
            // update price
            IWebElement editPricePerUnit = driver.FindElement(By.Id("Price"));
            editPricePerUnit.Clear();

            wait.WaitForElement(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 100);

            IWebElement editPrice1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            editPrice1.Click();

            wait.WaitForElementVisibility(driver, "id", "price", 20);
            IWebElement editPricePerUnit1 = driver.FindElement(By.Id("Price"));
            editPricePerUnit1.SendKeys("10000");

            wait.WaitForElementVisibility(driver, "XPath", "//*[@id='SaveButton']", 60);

            // select file



            // save edited data
            IWebElement editSavebutton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            editSavebutton.Click();
        } 

        //verify edited with random values
        internal bool IsEditCreated(IWebDriver driver, string editCode)
        {

            // wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 500);
            Thread.Sleep(5000);
            //goto last page
            IWebElement editLastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            editLastpage.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 100);
            //edited last test element selection
            IWebElement editedcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //-- another method assertion
           if (editedcode.Text == editCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //deleteTM
        public void DeleteTM(IWebDriver driver)
        {
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 20);
            //goto laste page
            IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastpage.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);
            // data to delete  
            IWebElement deleteDataCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            deleteDataCode.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 10);

            //delete button click
            IWebElement delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            delete.Click();
            Thread.Sleep(2000);


            //driver.SwitchTo().Alert().Accept();

            IAlert alert = driver.SwitchTo().Alert();
            Thread.Sleep(1000);

            // Accepting alert		
            alert.Accept();
            // validating deleted data
            try
            {
                IWebElement deleteText = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(deleteText.Text != "Sep 2020");
                Console.WriteLine("tm details deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine("delete method failed");
                Assert.Fail("deleteText failed", ex.Message);

            }

        }

        //Deleting randomly created values
        internal static void DeleteWithValues(IWebDriver driver)
        {
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 20);
            //goto laste page
            IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastpage.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);
            // data to delete  
            IWebElement deleteDataCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            deleteDataCode.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 10);

            //delete button click
            IWebElement delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            delete.Click();
            Thread.Sleep(2000);


            //driver.SwitchTo().Alert().Accept();

            IAlert alert = driver.SwitchTo().Alert();
            Thread.Sleep(1000);

            // Accepting alert		
            alert.Accept();
        }

        //validating randomly created n then deleted data

       
        internal bool IsRecordDeleted(IWebDriver driver, string editCode)
        {
            Thread.Sleep(5000);
            IWebElement deleteText = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (deleteText.Text != editCode)
            {
                Console.WriteLine("tm details deleted");
                return true;
            }
            else
            {
                Console.WriteLine("delete method failed");
                return false;

            }
        }


    }
}