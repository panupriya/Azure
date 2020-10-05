using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.helpers;
using September2020.pages;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace september2020
{
   
    [TestFixture , Description("this fixture contains time and material tests")]
    [Parallelizable]
   class Program : CommonDriver 
    {
        [Test , Description("Check if the user is create time successfully")]
            public void CreateNewTMTests()
            {
                //obj init and define for home page
                HomePage homepageobj = new HomePage();
                homepageobj.NavigateToTM(driver);

                // Test 1- check if the user is able to create time successfully

                //obj init and define for createTM
                TMpage createTmObj = new TMpage();
                createTmObj.CreateTM(driver);
            }

        [Test , Description("this test is to check user is able to edit time ")]
            public void EditTMTests()
            {
                //obj init and define for home page....
                //obj init and define for home page....
                HomePage homepageobj = new HomePage();
                homepageobj.NavigateToTM(driver);



                // Test 2- check if the user is able to edit time successfully
                TMpage editTmObj = new TMpage();
                editTmObj.EditTM(driver);
            }

           [Test , Description("this test is to check user is able to delete time ")]
            public void DeleteTMTests()
            {
                //obj init and define for home page
                HomePage homepageobj = new HomePage();
                homepageobj.NavigateToTM(driver);


                // Test 3- check if the user is able to delete time successfully
                TMpage deleteTmObj = new TMpage();
                deleteTmObj.DeleteTM(driver);

            }
    
   }
}









