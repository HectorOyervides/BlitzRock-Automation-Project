using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using Blitz.Shared.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blitz.Shared.PageObjects.Tenant.BusinessTrial;
using Blitz.Shared.Data;


namespace Blitz.Shared.PageObjects
{
    public class RequestAccessPage
    {
    
        public SharedFunctions sharedFunctions;
        public OpenBrowser browser = null;
        public RequestAccessPage(IWebDriver Driver)
        {

            PageFactory.InitElements(Driver, this);
        }


        [FindsBy(How = How.Name, Using = "Email")]
        public IWebElement requestAccessEmailTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement requestAccessFirstNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement requestAccessLastNameTextBox { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#wrapper > div > div.container > div > div > div > div > div.panel-body > form > fieldset > button")]
        public IWebElement requestAccessButton { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".panel-title")]
        public IWebElement requestSentLabel { get; set; }

        
        //Set keyword values.
        public void SetKeywords(ArrayList keywords, string testLog)
        {

            // call shared functions class. 
            sharedFunctions = new SharedFunctions();

            foreach (string keyword in keywords)
            {
                if (keyword.Contains(":"))
                {
                    String[] inputKeyword = keyword.Split(':');

                    switch (inputKeyword[0])
                    {
                        case "Email":
                            try
                            {
                                // Set email address
                                requestAccessEmailTextBox.SendKeys(inputKeyword[1]);
                                //Get email address to verify is correct.
                                string textBoxValue = requestAccessEmailTextBox.GetAttribute("value");

                                //Verify email address is correct and report to test log.
                                if (textBoxValue == inputKeyword[1])
                                {
                                    sharedFunctions.createTestLog(testLog, "Set Request Access Email:" + inputKeyword[1] + " [PASS: Email Address entered successfully]");
                                }
                                else
                                {
                                    sharedFunctions.createTestLog(testLog, "Set Request Access Email" + inputKeyword[1] + " [FAIL:Email Address not entered successfully]");
                                }

                            }

                            catch (Exception)
                            {

                                sharedFunctions.createTestLog(testLog, "Set Request Access Email" + inputKeyword[1] + " [FAIL: Email Address field is NOT Displayed]");
                            }

                            break;
                        

                        case "FirstName":
                            try
                            {
                                requestAccessFirstNameTextBox.SendKeys(inputKeyword[1]);
                                if (requestAccessFirstNameTextBox.GetAttribute("value") == inputKeyword[1])
                                {
                                    sharedFunctions.createTestLog(testLog, "Set First Name:" + inputKeyword[1] + " [PASS: First Name entered successfully]");
                                }
                                else
                                {
                                    sharedFunctions.createTestLog(testLog, "Set First Name:" + inputKeyword[1] + " [FAIL: First Name NOT entered successfully]");
                                }

                            }
                            catch (Exception)
                            {

                                sharedFunctions.createTestLog(testLog, "Set First Name:" + inputKeyword[1] + " [FAIL: First Name Field is NOT Displayed]");
                            }
                            break;

                        case "LastName":
                            try
                            {
                                requestAccessLastNameTextBox.SendKeys(inputKeyword[1]);
                                if (requestAccessLastNameTextBox.GetAttribute("value") == inputKeyword[1])
                                {
                                    sharedFunctions.createTestLog(testLog, "Set Last Name:" + inputKeyword[1] + " [PASS: Last Name entered successfully]");
                                }
                                else
                                {
                                    sharedFunctions.createTestLog(testLog, "Set Last Name:" + inputKeyword[1] + " [FAIL: Last Name NOT entered successfully]");
                                }

                            }
                            catch (Exception)
                            {

                                sharedFunctions.createTestLog(testLog, "Set Last Name:" + inputKeyword[1] + " [FAIL: First Name Field is NOT Displayed]");
                            }
                            break;

                        case "Submit":
                            try
                            {
                                requestAccessButton.Click();
                                Thread.Sleep(5000);
                                string requestLabelText = requestSentLabel.Text;
                                if (requestSentLabel.Text == "Request sent!")
                                {
                                    sharedFunctions.createTestLog(testLog, "Click on Send Request Button [PASS: Request Sent! label is Displayed]");
                                }
                                else
                                {
                                    sharedFunctions.createTestLog(testLog, "Click on Send Request Button [FAIL: Request Sent! label is NOT Displayed]");
                                }

                            }
                            catch (Exception)
                            {

                                sharedFunctions.createTestLog(testLog, "Click on Send Request Button [FAIL: Request Sent! label is NOT Displayed]");
                            }
                            break;
                    }
                }
            }
        }
    }
}
