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



namespace Blitz.Shared.PageObjects.Tenant.BlitzLegacy
{
    public class DashboardPage
    {
        public DashboardPage(IWebDriver Driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        SharedFunctions sharedFunctions = new SharedFunctions();

        [FindsBy(How = How.Id, Using = "sidebar")]
        private IWebElement cboMainHeader;

        [FindsBy(How = How.XPath, Using = "#Invoices8 > a")]
        private IWebElement sldInvoicesMenu;

        [FindsBy(How = How.Id, Using = "Create New Invoice9")]
        private IWebElement lnkCreateNewInvoice;



        public bool verify;

        public void SetKeywords(ArrayList keywords)
        {
            foreach (string keyword in keywords)
            {
                if (keyword.Contains(":"))
                {
                    String[] inputKeyword = keyword.Split(':');

                    switch (inputKeyword[0])
                    {
                        case "MainMenu":
                            verify = cboMainHeader.Displayed;
                            cboMainHeader.Click();
                            break;

                        case "Create New Invoice":
                            lnkCreateNewInvoice.Click();
                            break;

                    }
                }
            }
        }
    }
}

