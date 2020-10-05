using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace September2020.pages
{
    class LoginPage
    {
       public void LoginSteps(IWebDriver driver)
        {
            
         // launch browser using url
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

          // maximize web browser

            driver.Manage().Window.Maximize();

          // identify user name test box and enter user name
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

          //identify user passward text box and enter
            IWebElement passward = driver.FindElement(By.Id("Password"));
            passward.SendKeys("123123");

            // click on login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            try
            {
                // check login is successfull
                IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

                Assert.That(helloHari.Text == "Hello hari!");
            }
            catch(Exception ex)
            {
                Assert.Fail("Test failed at login step", ex.Message);
            }
        }
    }
}
