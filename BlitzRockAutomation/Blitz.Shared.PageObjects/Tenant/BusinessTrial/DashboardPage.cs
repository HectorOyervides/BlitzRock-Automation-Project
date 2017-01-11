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

namespace Blitz.Shared.PageObjects.Tenant.BusinessTrial
{
    public class GlobalDashboardPage
    {
        public GlobalDashboardPage(IWebDriver Driver)
        {
            PageFactory.InitElements(Driver, this);
        }


        SharedFunctions sharedFunctions = new SharedFunctions();

        [FindsBy(How = How.Id, Using = "sidebar")]
        private IWebElement cboMainHeader;

        public void SetKeywords(ArrayList keywords)
        {
            foreach (string keyword in keywords)
            {
                if (keyword.Contains(":"))
                {
                    String[] inputKeyword = keyword.Split(':');

                    switch (inputKeyword[0])
                    {
 
                 

                    }
                }
            }
        }
    }
}
