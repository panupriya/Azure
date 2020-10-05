using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.helpers;
using September2020.pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace September2020.test
{
    [TestFixture , Description("this fixture contains company tests")]
    [Parallelizable]
    class CompanyTests : CommonDriver
    {
      [Test , Description("Check if the user is create company successfully")]
        public void CreateNewCompanyTests()
        {
            //obj init and define for home page
            HomePage homepageobj = new HomePage();
            homepageobj.NavigateToCompany(driver);

            // Test 1- check if the user is able to create company successfully

            //obj init and define for createTM.
            CompanyPage createCompanyObj = new CompanyPage();
            createCompanyObj.CreateCompany(driver);

        }
        [Test , Description("this test is to check user is able to edit company details ")]
        public void EditCompanyTests()
        {
            //obj init and define for home page
            HomePage homepageobj = new HomePage();
            homepageobj.NavigateToCompany(driver);



            // Test 2- check if the user is able to edit company successfully
            CompanyPage editCompanyObj = new CompanyPage();
            editCompanyObj.EditCompany(driver);

        }
        [Test , Description("this test is to check user is able to delete company details ")]
        public void DeleteCompanyTests()
        {
            //obj init and define for home page
            HomePage homepageobj = new HomePage();
            homepageobj.NavigateToCompany(driver);


            // Test 3- check if the user is able to delete Company successfully
            CompanyPage deleteCompanyObj = new CompanyPage();
            deleteCompanyObj.DeleteCompany(driver);

        }
        
    }
}
