using OpenQA.Selenium;
using September2020.helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace September2020.pages
{
    class HomePage
    {
        public void NavigateToTM(IWebDriver driver)
        {
           
            // click administeation
            IWebElement administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administration.Click();

            //wait for the next xpath to load
            wait.WaitForElement(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a",5);
            

            //click time and material
            IWebElement timeandmaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeandmaterial.Click();
            
            wait.WaitForElement(driver, "XPath", "//*[@id='container']/p/a", 5);

              
        }
        public void NavigateToCompany(IWebDriver driver)
        {
            // click administeation
            IWebElement administrationC = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationC.Click();

            wait.WaitForElement(driver, "XPath","/html/body/div[3]/div/div/ul/li[5]/ul/li[6]/a", 5);

            //click company
            IWebElement company = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[6]/a"));
            company.Click();

            wait.WaitForElement(driver, "XPath", "//*[@id='container']/p/a", 5);
           

        }

    }
}
