using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace September2020.helpers
{
    class wait
    {
        //generic reusable wait function- ElementExist
        public static void WaitForElement (IWebDriver driver, string key,  string value, int seconds)
 
            {
                try
                {
                    if (key == "XPath")
                    {
                        var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(value)));
                    }
                    if (key == "Id")
                    {
                        var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(value)));
                    }
                    if (key == "CssSelector")
                    {
                        var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(value)));
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Test faied waiting for an webelement to be visible", ex.Message);
                }
           }


        //generic reusable wait function- ElementIsVisible
        public static void WaitForElementVisibility(IWebDriver driver, string key, string value, int seconds)
        {
            try
            {
                if (key == "XPath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(value)));
                }
                if (key == "Id")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(value)));
                }
                if (key == "CssSelector")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(value)));
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Test faied waiting for an webelement to be visible", ex.Message);
            }
        }
    }
}
