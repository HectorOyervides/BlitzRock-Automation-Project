using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blitz.Shared.Functions;


namespace Blitz.Shared.PageObjects
{
    public class CreateNewInvoicePage
    {
        public CreateNewInvoicePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        SharedFunctions sharedFunctions = new SharedFunctions();

        [FindsBy(How = How.Id, Using = "customer")]
        private IWebElement cboCustomer; // opt Bank of America

        [FindsBy(How = How.Id, Using = "customer-address")]
        private IWebElement cboAddress;

        [FindsBy(How = How.Id, Using = "payment-terms")]
        private IWebElement cboPaymentTerms; // opt Net 30

        [FindsBy(How = How.Id, Using = "control-label")]
        private IWebElement txtDiscountAmount;

        [FindsBy(How = How.Id, Using = "po-number")]
        private IWebElement cboReference;

        [FindsBy(How = How.Id, Using = "mainBeneficiary")]
        private IWebElement cboMainBeneficiary;

        [FindsBy(How = How.CssSelector, Using = ".fa.fa-plus-circle.pointer-cursor")]
        private IWebElement btnAddItem;

        [FindsBy(How = How.CssSelector, Using = "#select2-product-container")]
        private IWebElement cboProductName;

        [FindsBy(How = How.Id, Using = "description")]
        private IWebElement txtDescription;

        [FindsBy(How = How.Id, Using = "quantity")]
        private IWebElement txtQuantity;

        [FindsBy(How = How.Id, Using = "unit-cost")]
        private IWebElement txtUnitCost;

        [FindsBy(How = How.Id, Using = "tax-cost")]
        private IWebElement txtTax;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement txtTotalAmount;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-success")]
        private IWebElement btnSaveProduct;

        [FindsBy(How = How.Id, Using = "notes")]
        private IWebElement txtNotes;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-success.margin-right")]
        private IWebElement btnSave;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-danger")]
        private IWebElement btnCancel;

        [FindsBy(How = How.XPath, Using = "//*[@id='page-wrapper']/div[1]/div[1]/strong")]
        private IWebElement lblSuccess;

    }
}
