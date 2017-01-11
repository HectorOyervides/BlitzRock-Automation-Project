using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Data;
using System.IO;
using Blitz.Shared.Functions;
using Blitz.Shared.PageObjects;
using Blitz.Shared.PageObjects.Tenant.BlitzLegacy;
using Blitz.Shared.Data.DataFunctions;

namespace Blitz.Legacy
{
    [TestClass]
    public class RegresionTests
    {

        public ReadExcel readExcel = null;
        public OpenBrowser browser = null;
        public LoginPage loginPage = null;
        public DashboardPage dashboardPage = null;
        public DataTable configDatatable;
        public DataTable testMatrixDataTable;
        public DataTable testCaseDataTable;
        public string tenant;
        public string user;
        public string testLog;
        public string testsPath;
        public string password;
        public string url;
        public string browserEnvironment;
        public string configFile = "C:\\BlitzRock\\Configuration\\Configuration.xlsx";
        public string testMatrix;
        public string testCase;
        public string executionOrder;
        ArrayList keywords = new ArrayList();




        [TestInitialize]
        public void setup()
        {
            //Read Config File to get Blitz Version,Browser,and path to test matrix
            configDatatable = new DataTable();
            readExcel = new ReadExcel(configDatatable, configFile, "Config");

            foreach (DataRow row in configDatatable.Rows)
            {
                //number between brackets stands for column in the config file
                // column 0 = Blitz Version
                // column 1 = Url
                // column 2 = user
                // column 3 = password
                // column 4 = browser
                tenant = row[0].ToString();

                if (tenant == "Blitz Legacy")
                {
                    url = row[1].ToString();
                    user = row[2].ToString();
                    password = row[3].ToString();
                    browserEnvironment = row[4].ToString();
                    testMatrix = row[5].ToString();
                    testsPath = row[6].ToString();
                    testLog = row[7].ToString();
                    break;
                }

            }




        }

        [TestCleanup]
        public void tearDown()
        {
            browser.Driver.Quit();
        }

        [TestMethod]
        public void Blitz_Legacy_MainScript()
        {

            // Read Test Matrix
            testMatrixDataTable = new DataTable();
            readExcel = new ReadExcel(testMatrixDataTable, testMatrix, "TestCases");

            //Iterate Row by Row in test matrix
            foreach (DataRow testMatrixRow in testMatrixDataTable.Rows)
            {
                //Check if the test case wants to be executed.
                executionOrder = testMatrixRow[1].ToString();

                //If the test case corresponds to actual blitz version and wants to be executed proceed.
                if (executionOrder == "YES")
                {
                    //Get the path to the test case steps.
                    testCase = testsPath + testMatrixRow[0].ToString()+".xlsx";

                    //Open Browser
                    browser = new OpenBrowser(url, browserEnvironment);

                    //Read Test Case steps 
                    testCaseDataTable = new DataTable();
                    readExcel = new ReadExcel(testCaseDataTable, testCase, "TestCase");

                    //iterate in test case steps. (rows) 
                    foreach (DataRow testCaseRow in testCaseDataTable.Rows)
                    {
                        // Iterate in columns. 
                        foreach (DataColumn testCaseColumn in testCaseDataTable.Columns)
                        {
                            //Save the keywords (steps) in array for executions
                            keywords.Add(testCaseRow[testCaseColumn].ToString());

                        }

                        // search for page where keywords will be executed.
                        foreach (string keyword in keywords)
                        {

                            switch (keyword)
                            {
                                case "Login":
                                    loginPage = new LoginPage(browser.Driver);
                                    loginPage.SetKeywords(keywords);
                                    break;
                                case "Dashboard":
                                    dashboardPage = new DashboardPage(browser.Driver);
                                    dashboardPage.SetKeywords(keywords);
                                    break;

                                case "ExitApplication":
                                    browser.Driver.Quit();
                                    break;
                            }
                            //if Page is not found, clear the keywoords array and exit for each.
                            keywords.Clear();
                            break;
                        }
                    }
                }
            }
        }
    }
}
