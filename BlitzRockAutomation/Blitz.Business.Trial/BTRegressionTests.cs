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
using Blitz.Shared.PageObjects.Tenant.BusinessTrial;
using Blitz.Shared.Data.DataFunctions;

namespace Blitz.Version.Business.Trial
{
    [TestClass]
    public class RegresionTests
    {

        public ReadExcel readExcel = null;
        public OpenBrowser browser = null;
        public LoginPage loginPage = null;
        public BlitzMenu blitzMenu = null;
        public GlobalDashboardPage dashboardPage = null;
        public TransactionsAddNewDeal transactionAddNewDeal = null;
        public DataTable configDatatable;
        public DataTable testMatrixDataTable;
        public DataTable testCaseDataTable;
        public SharedFunctions sharedFunctions;
        public RequestAccessPage requestAccessPage;
        public string tenant;
        public string user;
        public string testLog;
        public string testsPath;
        public string password;
        public string url;
        public string browserEnvironment;
        //public string configFile = @"\\DF-APP-BLITZ-02\\SeleniumData\\BlitzRock\\Configuration\\Configuration.xlsx";
        public string configFile = "C:\\BlitzRock\\Configuration\\Configuration.xlsx";
        public string testMatrix;
        public string testCase;
        public string testCasePath;
        public string filename;
        public string executionOrder;
        public string globalLog;
        ArrayList passedTestCases = new ArrayList();
        ArrayList failedTestCases = new ArrayList();
        ArrayList executedTestCases = new ArrayList();
        ArrayList keywords = new ArrayList();
        public int passedCounter =0;
        public int failedCounter = 0;




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

                if (tenant == "Blitz Business Trial")
                {
                    tenant = row[0].ToString();
                    url = row[1].ToString();
                    user = row[2].ToString();
                    password = row[3].ToString();
                    browserEnvironment = row[4].ToString();
                    testMatrix = row[5].ToString();
                    testsPath = row[6].ToString();
                    testLog = row[7].ToString();
                    globalLog = row[8].ToString();
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
        public void Blitz_Business_Trial_MainScript()
        {

            // Read Test Matrix
            testMatrixDataTable = new DataTable();
            readExcel = new ReadExcel(testMatrixDataTable, testMatrix, "TestCases");
            // call shared functions class. 
            sharedFunctions = new SharedFunctions();


            //Iterate Row by Row in test matrix
            foreach (DataRow testMatrixRow in testMatrixDataTable.Rows)
            {
                //Check if the test case wants to be executed.
                executionOrder = testMatrixRow[1].ToString();

                // get the test case name from excel file. 
                testCase = testMatrixRow[0].ToString();

                // assign a date format to the test case name.
                filename = String.Format("{0:yyyy-MM-dd--hh-mm-ss}_{1}", DateTime.Now, testCase + ".txt");

                // combine the test case name and the path for the log. 
                testCasePath = Path.Combine(testLog, filename);

                //If the test case corresponds to actual blitz version and wants to be executed proceed.
                if (executionOrder == "YES")
                {
                    //Save executed Test Case for Report.
                    executedTestCases.Add(testCasePath);

                    // create individual testlog for test case calling the test name and test path. 
                    sharedFunctions.createTestLog(testCasePath, testCase);

                    //Get the path to the test case steps and replace variable.
                    testCase = testsPath + testMatrixRow[0].ToString() + ".xlsx";

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
                        switch (keywords[0].ToString())
                        {
                            case "Login":
                                loginPage = new LoginPage(browser.Driver);
                                loginPage.SetKeywords(keywords, testCasePath);
                                break;
                            case "RequestAccess":
                                requestAccessPage = new RequestAccessPage(browser.Driver);
                                requestAccessPage.SetKeywords(keywords, testCasePath);
                                break;
                            case "BlitzMenu":
                                blitzMenu = new BlitzMenu(browser.Driver);
                                blitzMenu.SetKeywords(keywords);
                                break;

                            case "AddNewDeal":
                                transactionAddNewDeal = new TransactionsAddNewDeal(browser.Driver);
                                transactionAddNewDeal.SetKeywords(keywords);
                                break;

                            case "ExitApplication":
                                browser.Driver.Quit();
                                break;
                        }
                        //if Page is not found, clear the keywords array and move next test case row.
                        keywords.Clear();
                    }
                }
            }

            // Create final reports.


            foreach (var executedTestCase in executedTestCases)
            {
                // Set steps summary to test cases.and set Global execution report
                if (sharedFunctions.readTestLog(executedTestCase.ToString()) == true)
                {
                    //Set passed test cases.
                    passedTestCases.Add(executedTestCase);
                    passedCounter = passedCounter + 1;
                }
                else
                {
                    //Set failed Test cases. 
                    failedTestCases.Add(executedTestCase);
                    failedCounter = failedCounter + 1;

                }


            }
            // assign a date format to the test case name.
            globalLog = globalLog + String.Format("{0:yyyy-MM-dd--hh-mm-ss}  {1}", DateTime.Now, tenant + " ExecutionReport.html");
            sharedFunctions.createGlobalLog(globalLog, passedCounter, failedCounter);

            if (passedCounter != 0)
            {
                //Create passed tests table-
                sharedFunctions.createTestLog(globalLog, "<center><table style=width:75%>" +
                                                        "<caption><b>Passed Tests</b></caption>" +
                                                        "<tr><td bgcolor=blue><font color =white>Test Case</td>" +
                                                        "<td bgcolor = blue><font color=white>Test Case Location</td></tr>");
                foreach (var passedTest in passedTestCases)
                {
                    String[] testCaseName = passedTest.ToString().Split('\\');//14
                    sharedFunctions.createTestLog(globalLog, "<tr><td>" + testCaseName[10].ToString() + "</td><td><a href=" + passedTest.ToString() +
                        ">" + passedTest.ToString() + "</td></tr>");

                }
                sharedFunctions.createTestLog(globalLog, "</table></center><br><br>");
            }

            if (failedCounter != 0)
            {
                //Create failed tests table. 
                sharedFunctions.createTestLog(globalLog, "<center><table style=width:75%>" +
                                                        "<caption><b>Failed Tests</b></caption>" +
                                                        "<tr><td bgcolor=blue><font color =white>Test Case</td>" +
                                                        "<td bgcolor = blue><font color=white>Test Case Location</td></tr>");

                foreach (var failedTest in failedTestCases)
                {
                    String[] testCaseName = failedTest.ToString().Split('\\');
                    sharedFunctions.createTestLog(globalLog, "<tr><td>" + testCaseName[10].ToString() + "</td><td><a href=" + failedTest.ToString() +
                        ">" + failedTest.ToString() + "</td></tr>");

                }
            }
          
            // Send email report.
            sharedFunctions.SendResults(globalLog);
        }
    }
}

