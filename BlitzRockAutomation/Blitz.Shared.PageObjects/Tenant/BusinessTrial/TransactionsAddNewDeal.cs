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
    public class TransactionsAddNewDeal
    {


        public TransactionsAddNewDeal(IWebDriver Driver)
        {
            PageFactory.InitElements(Driver, this);
            Thread.Sleep(5000);
        }


        [FindsBy(How = How.CssSelector, Using = "#ReceiptDetails > div > div.col-xs-12.col-sm-12.col-md-8.col-lg-8 > form > div > div.panel-body.user-margin-form > div:nth-child(1) > div:nth-child(2) > div.row.ng-scope > dynamic-fields:nth-child(1) > div:nth-child(2) > span > span > span.k-input.ng-scope")]
        private IWebElement typeOfDeal;


        public void SetKeywords(ArrayList keywords)
        {
            foreach (string keyword in keywords)
            {
                if (keyword.Contains(":"))
                {
                    String[] inputKeyword = keyword.Split(':');

                    
                        switch (inputKeyword[0])
                        {
                            case "TypeOfDeal":

                            SelectElement dealtypeDropdown = new SelectElement(typeOfDeal);
                            dealtypeDropdown.SelectByValue(inputKeyword[1]);
                           
                            break;

                        }

                    
                }
            }
        }
    }
}
