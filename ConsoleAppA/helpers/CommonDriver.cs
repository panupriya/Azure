using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace September2020.helpers
{
    class CommonDriver
    {
        //int driver;
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void LoginToTurnup()
        {
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)   
            // web driver
            driver = new ChromeDriver();

            //obj init and define for loginpage
            LoginPage loginObject = new LoginPage();
            loginObject.LoginSteps(driver);
            Thread.Sleep(1000);
        }


        [OneTimeTearDown]
        public void TestClousure()
        {
            // close instances of open chrome driver
            driver.Quit();
        }
    }
}
