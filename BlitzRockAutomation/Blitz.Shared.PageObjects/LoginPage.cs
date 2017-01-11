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
    public class LoginPage
    {
        public RequestAccessPage requestAccessPage= null;
        public SharedFunctions sharedFunctions;
        public OpenBrowser browser = null;

        public LoginPage(IWebDriver Driver)
        {

            PageFactory.InitElements(Driver, this);


        }
        //Set Objects 
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement emailTextBox { get; set; }


        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement passwordTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#wrapper > div > div.container > div > div > div > div > div.panel-body > form > fieldset > button")]
        public IWebElement submit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*/div/div[2]/div/div/div/div/div[2]/form/fieldset/div[3]/div/a")]
        public IWebElement forgotPassword { get; set; }


        [FindsBy(How = How.XPath, Using = "//*/div/div[2]/div/div/div/div[1]/div[1]/h3")]
        public IWebElement forgotPasswordLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#wrapper > div > div.container > div > div > div > div:nth-child(1) > div.panel-body > form > fieldset > button")]
        public IWebElement forgotPasswordSubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*/div/div[2]/div/div/div/div/div[1]/p/a")]
        public IWebElement requestNewAccess { get; set; }

        [FindsBy(How = How.XPath, Using = " //*/div/div[2]/div/div/div/div/div[1]/h3")]
        public IWebElement requestAccessLabel { get; set; }

       // [FindsBy(How = How.CssSelector, Using = ".navbar-text > span:nth-child(1)")]
      //  public IWebElement tenantLabel { get; set; }


        [FindsBy(How = How.Id, Using = "MyBlitz1")]
        public IWebElement tenantLabel { get; set; }

        

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
                                emailTextBox.SendKeys(inputKeyword[1]);
                                //Get email address to verify is correct.
                                string textBoxValue = emailTextBox.GetAttribute("value");

                                //Verify email address is correct and report to test log.
                                if (textBoxValue == inputKeyword[1])
                                {
                                    sharedFunctions.createTestLog(testLog, "Set Email:" + inputKeyword[1] + " [PASS: Email Address entered successfully]");
                                }
                                else
                                {
                                    sharedFunctions.createTestLog(testLog, "Set Email" + inputKeyword[1] + " [FAIL:Email Address not entered successfully]");
                                }

                            }

                            catch (Exception)
                            {

                                sharedFunctions.createTestLog(testLog, "Set Email" + inputKeyword[1] + " [FAIL: Email Address field is NOT Displayed]");
                            }
                            break;
                      
                        case "Password":
                            try
                            {
                                // set password.
                                passwordTextBox.SendKeys(inputKeyword[1]);
                                // get password to verify is the one from the config file
                                string passwordValue = passwordTextBox.GetAttribute("value");
                                // verify the password is correct and report to test log.
                                if (passwordValue == inputKeyword[1])
                                {
                                    sharedFunctions.createTestLog(testLog, "Set Password:" + inputKeyword[1] + " [PASS: Password entered successfully]");

                                }
                                else
                                {
                                    sharedFunctions.createTestLog(testLog, "Set Password:" + inputKeyword[1] + " [FAIL: Password NOT entered successfully]");
                                }

                            }
                            catch (Exception)
                            {

                                sharedFunctions.createTestLog(testLog, "Set Password:" + inputKeyword[1] + " [FAIL: Password field is NOT Displayed]");
                            }

                            break;



                        case "Forgot Password?":
                            try
                            {
                                forgotPassword.Click();
                                Thread.Sleep(2000);
                                if (forgotPasswordLabel.Displayed == true && emailTextBox.Displayed == true && forgotPasswordSubmitButton.Displayed == true)
                                {
                                    sharedFunctions.createTestLog(testLog, "Click On Forgot your password? [PASS: Forgot Password page is Displayed]");
                                }

                            }
                            catch (Exception)
                            {

                                sharedFunctions.createTestLog(testLog, "Click On Forgot your password? [FAIL Forgot your password? Link is NOT Displayed]");
                            }

                            break;

                        

                        case "Submit":
                            try
                            {

                                submit.Click();
                                Thread.Sleep(5000);
                                if (tenantLabel.Displayed)
                                {
                                    sharedFunctions.createTestLog(testLog, "Click on Submit and Verify you entered Blitz[PASS: Blitz Menus are Displayed]");
                                }
                                else
                                {
                                    sharedFunctions.createTestLog(testLog, "Click on Submit and Verify you entered Blitz[FAIL: Blitz Menus are NOT Displayed]");
                                }
                            }
                            catch (Exception)
                            {

                                sharedFunctions.createTestLog(testLog, "Click on Submit and Verify you entered Blitz[FAIL: Blitz Menus are NOT Displayed]");

                            }

                            break;

                        case "RequestAccess":
                            try
                            {
                                
                                requestNewAccess.Click();
                                Thread.Sleep(2000);
                                if (requestAccessLabel.Displayed == true)
                                {
                                    if (requestAccessLabel.Text == "Request Access")
                                    {
                                        sharedFunctions.createTestLog(testLog, "Click On Request Access [PASS: Request Access Page is Displayed]");
                                    }
                                    
                                }
                                else
                                {
                                    sharedFunctions.createTestLog(testLog, "Click On Request Access [FAIL: Request Access Page is NOT Displayed]");
                                }

                            }
                            catch (Exception)
                            {
                                sharedFunctions.createTestLog(testLog, "Click On Request Access [FAIL: Request Access Page is NOT Displayed]");
                            }
                            break;

                    }
                }
            }
        }
    }
}
