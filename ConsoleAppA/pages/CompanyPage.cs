using NUnit.Framework;
using OpenQA.Selenium;
using September2020.helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace September2020.pages
{
    class CompanyPage
    {
        public void CreateCompany(IWebDriver driver)
        {
            try
            {
                //click createnew company
                IWebElement createnewCompany = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                createnewCompany.Click();

                wait.WaitForElement(driver, "XPath", "//*[@id='Name']", 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("test fails at createnew company", ex.Message);
            }

            //input company name
            IWebElement name = driver.FindElement(By.XPath("//*[@id='Name']"));
            name.SendKeys("ABC LTD");

            wait.WaitForElement(driver, "XPath", "//*[@id='EditContactButton']", 5);

            //EditCompany contact
            IWebElement editbutton = driver.FindElement(By.XPath("//*[@id='EditContactButton']"));
            editbutton.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='contactDetailWindow']/iframe", 20);

            //switch to contact details window
            IWebElement iframe = driver.FindElement(By.XPath("//*[@id='contactDetailWindow']/iframe"));

            driver.SwitchTo().Frame(iframe);

            //input contact details
            IWebElement firstName = driver.FindElement(By.Id("FirstName"));
            firstName.SendKeys("Abc");
            wait.WaitForElementVisibility(driver, "Id", "LastName", 5);


            IWebElement lastName = driver.FindElement(By.Id("LastName"));
            lastName.SendKeys("Def");
            wait.WaitForElementVisibility(driver, "Id", "PreferedName", 5);

            IWebElement preferedName = driver.FindElement(By.Id("PreferedName"));
            preferedName.SendKeys("Abc");
            wait.WaitForElementVisibility(driver, "Id", "Phone", 5);


            IWebElement phone = driver.FindElement(By.Id("Phone"));
            phone.SendKeys("0435407521");
            wait.WaitForElementVisibility(driver, "Id", "Mobile", 5);


            IWebElement mobile = driver.FindElement(By.Id("Mobile"));
            mobile.SendKeys("9746142692");
            /*wait.WaitForElementVisibility(driver, "Id", "mail", 5);

            IWebElement mail = driver.FindElement(By.Id("mail"));
            mobile.SendKeys("abc@gmail.com");*/
            wait.WaitForElementVisibility(driver, "XPath", "//*[@id='autocomplete']", 5);

            IWebElement address = driver.FindElement(By.XPath("//*[@id='autocomplete']"));
            address.SendKeys("50A");
            wait.WaitForElementVisibility(driver, "Id", "Street", 5);

            IWebElement street = driver.FindElement(By.Id("Street"));
            street.SendKeys("ann street");
            wait.WaitForElementVisibility(driver, "Id", "City", 5);

            IWebElement city = driver.FindElement(By.Id("City"));
            city.SendKeys("Brisbane");
            wait.WaitForElementVisibility(driver, "Id", "Postcode", 5);

            IWebElement postcode = driver.FindElement(By.Id("Postcode"));
            postcode.SendKeys("4000");
            wait.WaitForElementVisibility(driver, "Id", "Country", 5);

            IWebElement country = driver.FindElement(By.Id("Country"));
            country.SendKeys("Australia");
            wait.WaitForElement(driver, "Xpath", "//*[@id='submitButton']", 5);

            IWebElement saveContacts = driver.FindElement(By.XPath("//*[@id='submitButton']"));
            saveContacts.Click();
            Thread.Sleep(5000);

            driver.SwitchTo().DefaultContent();
            Thread.Sleep(3000);

            // check if contact created successfully
            try
            {
                IWebElement contactBox = driver.FindElement(By.XPath("//*[@id='ContactDisplay']"));
                IWebElement billingContactBox = driver.FindElement(By.XPath("//*[@id='BillingContactDisplay']"));
                Assert.That(contactBox.GetAttribute("value") == billingContactBox.GetAttribute("value"));
                Console.WriteLine("CreateCompany contact added");
            }
            catch (Exception ex)
            {
                Assert.Fail("contactBox.Text != billingContactBox.Text", ex.Message);
                Thread.Sleep(3000);
            }
                // create new group
                wait.WaitForElement(driver, "Xpath", "//*[@id='CreateGroupButton']", 50);

                IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id='CreateGroupButton']"));
                createnewButton.Click();
            //wait.WaitForElement(driver, "Xpath", "//*[@id='groupDetailWindow_wnd_title']/iframe", 5);
            Thread.Sleep(10000);

            // switch to iframe
            try
            {
                IWebElement iframeAddgroup = driver.FindElement(By.XPath("//*[@id='groupDetailWindow']/iframe"));
                driver.SwitchTo().Frame(iframeAddgroup);
                //wait.WaitForElement(driver, "Xpath", "//*[@id='Name']", 200);
                Thread.Sleep(5000);
            }

            catch(Exception ex)
            {
                Console.WriteLine("cannot switchon to iframe", ex.Message);
            }


            
            // input group name
            IWebElement groupName = driver.FindElement(By.XPath("//*[@id='Name']"));
                groupName.SendKeys("Aussie group");
                wait.WaitForElement(driver, "Xpath", "//*[@id='SaveButton']", 5);

                //  saveGroup 
                IWebElement saveGroup = driver.FindElement(By.XPath("//*[@id='GroupEditForm']/div/div[2]/div/input[1]"));
                saveGroup.Click();
                Thread.Sleep(3000);

                //back no normal display page
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(3000);

                wait.WaitForElement(driver, "XPath", "//*[@id='groupGrid']/div[4]/a[4]/span", 20);
                //goto groups last page                                   
                IWebElement groupLastPage = driver.FindElement(By.XPath("//*[@id='groupGrid']/div[4]/a[4]/span"));
                groupLastPage.Click();
                Thread.Sleep(5000);

                // validate if the new group has been created successfully
                try
                {
                    //wait.WaitForElement(driver, "Xpath", "//*[@id='groupGrid']/div[2]/table/tbody/tr[last()]/td[2]", 5);
                    IWebElement lastpageGroupDisplay = driver.FindElement(By.XPath("//*[@id='groupGrid']/div[2]/table/tbody/tr[last()]/td[2]"));
                     Assert.That(lastpageGroupDisplay.Text == "Aussie group");
                     Thread.Sleep(3000);
                Console.WriteLine("group saved successfully");
                }
                catch(Exception ex)
                {
                    Assert.Fail("createnewgroup created test failed",ex.Message);
                }
           
            //save company
            IWebElement saveCompanynew = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
                saveCompanynew.Click();
                Thread.Sleep(5000);

                try
                {
                    //goto last page
                    wait.WaitForElement(driver, "Xpath", "//*[@id=''companiesGrid']/div[4]/a[4]", 400);
                    IWebElement saveCompanyEndpage = driver.FindElement(By.XPath("//*[@id=''companiesGrid']/div[4]/a[4]"));
                    saveCompanyEndpage.Click();

                }
                catch(Exception ex)
                {
                    Console.WriteLine("goto last page to last page successfull", ex.Message);
                }

                // validating if data stored successfully by checking last page last element
                wait.WaitForElement(driver, "Xpath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 400);
                IWebElement companyLastpageLastelement = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(companyLastpageLastelement.Text, Is.EqualTo("ABC LTD"));


        }
        public void EditCompany(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            //wait.WaitForElement(driver, "XPath", "//*[@id=''companiesGrid']/div[4]/a[4]/span", 500);
           
            //go to last page
            try
            {
                IWebElement editCompanyEndpage = driver.FindElement(By.XPath("//*[@id=''companiesGrid']/div[4]/a[4]/span"));
                editCompanyEndpage.Click();
                
                driver.Navigate().Refresh();
            }
            catch(Exception ex)
            {
                Console.WriteLine("go to last page failed", ex.Message);
            }
            Thread.Sleep(500);
            //select last page last element
            try
            {
               // wait.WaitForElement(driver, "Xpath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 4000);
                IWebElement editLastpageLastelement = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                editLastpageLastelement.Click();
            }
            catch(Exception ex)
            {
                Console.WriteLine("failed to load last page", ex.Message);
            }
            //click edit button
            Thread.Sleep(5000);
            try
            {
               //wait.WaitForElement(driver, "Xpath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]", 400);
                driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]")).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to click edit button", ex.Message);
            }
            //edit name
            wait.WaitForElement(driver, "XPath", "//*[@id='Name']", 500);

            driver.FindElement(By.XPath("//*[@id='Name']")).Clear();
            driver.FindElement(By.XPath("//*[@id='Name']")).SendKeys("ABC LTD NEW");

            wait.WaitForElement(driver, "XPath", "//*[@id='EditContactButton']", 5);

            //re editCompany contact
            driver.FindElement(By.XPath("//*[@id='EditContactButton']")).Click();
     
             wait.WaitForElement(driver, "XPath", "//*[@id='contactDetailWindow']/iframe", 20);

            //switch to contact details window
            IWebElement iframeedit = driver.FindElement(By.XPath("//*[@id='contactDetailWindow']/iframe"));

            driver.SwitchTo().Frame(iframeedit);

            //edit input contact details
            wait.WaitForElementVisibility(driver, "Id", "FirstName", 5);
            driver.FindElement(By.Id("FirstName")).Clear();
           driver.FindElement(By.Id("FirstName")).SendKeys("Abc New"); 
           
            wait.WaitForElementVisibility(driver, "Id", "LastName", 5);
            driver.FindElement(By.Id("LastName")).Clear();
            driver.FindElement(By.Id("LastName")).SendKeys("Def New");


            wait.WaitForElementVisibility(driver, "Id", "PreferedName", 5);
            driver.FindElement(By.Id("PreferedName")).Clear();
            driver.FindElement(By.Id("PreferedName")).SendKeys("Abc new");

            wait.WaitForElementVisibility(driver, "Id", "Phone", 5);
            driver.FindElement(By.Id("Phone")).Clear();
            driver.FindElement(By.Id("Phone")).SendKeys("0435407522");


            wait.WaitForElementVisibility(driver, "Id", "Mobile", 5);
            driver.FindElement(By.Id("Mobile")).Clear();
            driver.FindElement(By.Id("Mobile")).SendKeys("9746142693");


            //save edited contact
            driver.FindElement(By.XPath("//*[@id='submitButton']")).Click();
           
            Thread.Sleep(5000);

            driver.SwitchTo().DefaultContent();
            Thread.Sleep(3000);

            // check if edited contact created successfully
            try
            {
                IWebElement editedcontactBox = driver.FindElement(By.XPath("//*[@id='ContactDisplay']"));
                IWebElement editedbillingContactBox = driver.FindElement(By.XPath("//*[@id='BillingContactDisplay']"));
                Assert.That(editedcontactBox.GetAttribute("value") == editedbillingContactBox.GetAttribute("value"));
                Console.WriteLine("CreateCompany contact edited passed");
            }
            catch (Exception ex)
            {
                Assert.Fail("editedcontactBox.Text != editedbillingContactBox.Text", ex.Message);
                Thread.Sleep(3000);
            }
            // create new group name
            wait.WaitForElement(driver, "Xpath", "//*[@id='CreateGroupButton']", 50);
            driver.FindElement(By.XPath("//*[@id='CreateGroupButton']")).Click();


            //wait.WaitForElement(driver, "Xpath", "//*[@id='groupDetailWindowWindow']/iframe", 5);
            Thread.Sleep(10000);

            // switch to iframe
            try
            {
                IWebElement iframeeditAddgroup = driver.FindElement(By.XPath("//*[@id='groupDetailWindow']/iframe"));
                driver.SwitchTo().Frame(iframeeditAddgroup);
                //wait.WaitForElement(driver, "Xpath", "//*[@id='Name']", 200);
                Thread.Sleep(5000);
            }

            catch (Exception ex)
            {
                Console.WriteLine("cannot switchon to iframe", ex.Message);
            }



            // edit create new group name
            wait.WaitForElement(driver, "Xpath", "//*[@id='Name']", 50);
            driver.FindElement(By.XPath("//*[@id='Name']")).Clear();
            driver.FindElement(By.XPath("//*[@id='Name']")).SendKeys("Aussie group new");

            wait.WaitForElement(driver, "Xpath", "//*[@id='SaveButton']", 5);

            // IWebElement saveGroup = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            driver.FindElement(By.XPath("//*[@id='GroupEditForm']/div/div[2]/div/input[1]")).Click();
            
            Thread.Sleep(3000);

            //back no normal display page
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(3000);

            wait.WaitForElement(driver, "XPath", "//*[@id='groupGrid']/div[4]/a[4]/span", 20);
            //goto groups last page  to check if it is edited or not                                 
            IWebElement editgroupLastPage = driver.FindElement(By.XPath("//*[@id='groupGrid']/div[4]/a[4]/span"));
            editgroupLastPage.Click();
            Thread.Sleep(5000);

            // validate if the new group has been edited successfully
            try
            {
                //wait.WaitForElement(driver, "Xpath", "//*[@id='groupGrid']/div[2]/table/tbody/tr[last()]/td[2]", 5);
                IWebElement editlastpageGroupDisplay = driver.FindElement(By.XPath("//*[@id='groupGrid']/div[2]/table/tbody/tr[last()]/td[2]"));
                Assert.That(editlastpageGroupDisplay.Text == "Aussie group new");
                Thread.Sleep(3000);
                Console.WriteLine("group saved successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("createnewgroup created test failed", ex.Message);
            }

            //save edited company details
            IWebElement editsaveCompanynew = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            editsaveCompanynew.Click();
            Thread.Sleep(5000);

            try
            {
                //goto last page
                wait.WaitForElement(driver, "Xpath", "//*[@id=''companiesGrid']/div[4]/a[4]", 400);
                IWebElement saveeditedCompanyEndpage = driver.FindElement(By.XPath("//*[@id=''companiesGrid']/div[4]/a[4]"));
                saveeditedCompanyEndpage.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine("goto last page to last page successfull", ex.Message);
            }

            // validating if edited data stored successfully by checking last page last element
            wait.WaitForElement(driver, "Xpath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 400);
            IWebElement editedcompanyLastpageLastelement = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(editedcompanyLastpageLastelement.Text, Is.EqualTo("ABC LTD NEW"));


        }
        public void DeleteCompany(IWebDriver driver)
        {
                driver.Navigate().Refresh();
                Thread.Sleep(2000);
            wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[4]/a[4]", 4000);
            try
            {
                //go to last company page

                driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[4]/a[4]")).Click();
                driver.Navigate().Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine("canonot find last page", ex.Message);
            }
                try
                {
                    // select last element to delete
                    wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 4000);
                    driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Click();
                    Thread.Sleep(4000);
                }
                catch
                {
                    Console.WriteLine("cannot select the last element");
                }
   
                // click delete button
                wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]", 4000);
                driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]")).Click();
            

            //driver.SwitchTo().Alert().Accept();
            IAlert alert = driver.SwitchTo().Alert();
                Thread.Sleep(1000);

                // Accepting alert		
                alert.Accept();
                Thread.Sleep(1000);
            /* to cancel alert use
            alert.Dismiss();*/

                // validating deleted data
                try
                {
                    wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 400);
                    IWebElement deleteCompanyText = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                    Assert.That(deleteCompanyText.Text != "ABC LTD");
                    Console.WriteLine("company details deleted");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("delete method failed");
                    Assert.Fail("deleteText failed", ex.Message);

                }
        }

    }
}    