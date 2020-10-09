using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.pages;
using System.Threading;
using TechTalk.SpecFlow;

namespace September2020.Step_Definition
{
    [Binding]
    public sealed class CompanyStepDefinition
    {

        IWebDriver driver;

        [BeforeScenario]
        public void LoginToTurnup()
        {

            driver = new ChromeDriver();
            //obj init and define for loginpage
            LoginPage loginObject = new LoginPage();
            loginObject.LoginSteps(driver);
            Thread.Sleep(1000);
        }

        [AfterScenario]
        public void Dispose()
        {
            // close the window and release the memory
            driver.Dispose();
        }

       //background
        [Given(@"I navigate to company page")]
        public void GivenINavigateToCompanyPage()
        {
            var homepage = new HomePage();
            homepage.NavigateToCompany(driver);
            Thread.Sleep(1000);
        }
        //create , edit and delete company in one scenario
       
        //1.create company
        [When(@"I create new company using company name")]
        public void WhenICreateNewCompanyUsingCompanyName()
        {
            var companyPage = new CompanyPage();
            companyPage.CreateCompanyWithValues(driver);
        }
        [When(@"I am able to varify created company with company name")]
        public void WhenIAmAbleToVarifyCreatedCompanyWithCompanyName()
        {
            var companyPage = new CompanyPage();
            companyPage.ValidateCreateCompanyWithValues(driver);

        }


        //2.wdit company
        [When(@"I edit created company with another company name and group name")]
        public void WhenIEditCreatedCompanyWithAnotherCompanyNameAndGroupName()
        {

            var editcompanyPage = new CompanyPage();
            editcompanyPage.EditCreateCompanyWithValues(driver);

        }
        [When(@"I am ableto verify edited company with edited name")]
        public void WhenIAmAbletoVerifyEditedCompanyWithEditedName()
        {
            var editcompanyPage = new CompanyPage();

                var result = CompanyPage.IsEditRecordCreated(driver);
              Assert.IsTrue(result, "NO TM Record created for code : ");
        }

        //3.delete company
        [When(@"I detete edited company")]
        public void WhenIDeteteEditedCompany()
        {
            var deletecompanyPage = new CompanyPage();
            deletecompanyPage.DeleteCreatedCompanyWithValues(driver);
        }
        [Then(@"I am able to verify edited company got deleted")]
        public void ThenIAmAbleToVerifyEditedCompanyGotDeleted()
        {
            var deletecompanyPage = new CompanyPage();

            var result = CompanyPage.IsRecordDeleted(driver);
            Assert.IsTrue(result, "NO TM Record created for code : ");
        }



    }
}
