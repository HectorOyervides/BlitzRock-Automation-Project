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
    public class BlitzMenu
    {

        public BlitzMenu(IWebDriver Driver)
        {
            PageFactory.InitElements(Driver, this);
            Thread.Sleep(10000);
        }


        [FindsBy(How = How.Id, Using = "MyBlitz1")]
        public IWebElement myBlitzMenu;

        [FindsBy(How = How.Id, Using = "Globaldashboard3")]
        private IWebElement myBlitzMenu_GlobalDashboard;

        [FindsBy(How = How.Id, Using = "Teamdashboard4")]
        private IWebElement myBlitzMenu_TeamDashboard;

        [FindsBy(How = How.Id, Using = "Salespersondashboard5")]
        private IWebElement myBlitzMenu_SalesPersonDashboard;

        [FindsBy(How = How.Id, Using = "Paidcommissions7")]
        private IWebElement myBlitzMenu_paidCommissions;

        [FindsBy(How = How.Id, Using = "Forecastedcommissions8")]
        private IWebElement myBlitzMenu_forecastedCommissions;

        [FindsBy(How = How.Id, Using = "Duecommissions9")]
        private IWebElement myBlitzMenu_dueCommissions;

        [FindsBy(How = How.Id, Using = "Submittedforapproval10")]
        private IWebElement myBlitzMenu_submittedForApproval;


        [FindsBy(How = How.Id, Using = "CompensationPlans11")]
        private IWebElement compensationPlansMenu;

        [FindsBy(How = How.Id, Using = "Viewall13")]
        private IWebElement compensationPlans_viewAll;

        [FindsBy(How = How.Id, Using = "Addnewplan14")]
        private IWebElement compensationPlans_addNewPlan;

        [FindsBy(How = How.Id, Using = "Viewallgoals16")]
        private IWebElement compensationPlans_viewAllGoals;

        [FindsBy(How = How.Id, Using = "Transactions17")]
        private IWebElement transactionsMenu;

        [FindsBy(How = How.Id, Using = "Viewalldeals19")]
        private IWebElement transactions_ViewAllDeals;

        [FindsBy(How = How.Id, Using = "Addnewdeal20")]
        private IWebElement transactions_AddNewDeal;

        [FindsBy(How = How.Id, Using = "Viewallagentcharges22")]
        private IWebElement transactions_ViewAllAgentCharges;

        [FindsBy(How = How.Id, Using = "Addnewagentcharge23")]
        private IWebElement transactions_AddNewAgentCharge;

        [FindsBy(How = How.Id, Using = "Dealtype25")]
        private IWebElement transactions_DealType;

        [FindsBy(How = How.Id, Using = "Periods26")]
        private IWebElement transactions_Periods;

        [FindsBy(How = How.Id, Using = "Dealsources27")]
        private IWebElement transactions_DealSource;

        [FindsBy(How = How.Id, Using = "States28")]
        private IWebElement transactions_States;

        [FindsBy(How = How.Id, Using = "Dealstatus29")]
        private IWebElement transactions_DealStatus;

        [FindsBy(How = How.Id, Using = "Teams30")]
        private IWebElement transactions_Teams;

        [FindsBy(How = How.Id, Using = "Companyroles31")]
        private IWebElement transactions_CompanyRoles;

        [FindsBy(How = How.Id, Using = "Tiers32")]
        private IWebElement transactions_Tiers;

        [FindsBy(How = How.Id, Using = "Commissions33")]
        private IWebElement commissionsMenu;

        [FindsBy(How = How.Id, Using = "Paycommissions35")]
        private IWebElement commissions_PayCommissions;

        [FindsBy(How = How.Id, Using = "Viewhistory36")]
        private IWebElement commissions_ViewHistory;

        [FindsBy(How = How.Id, Using = "menu-custom37")]
        private IWebElement customMenu;

        [FindsBy(How = How.Id, Using = "Viewallusers39")]
        private IWebElement customMenu_viewAllUsers;

        [FindsBy(How = How.Id, Using = "Invitenewusers40")]
        private IWebElement customMenu_inviteNewUsers;

        [FindsBy(How = How.Id, Using = "Viewallpaymentperiods42")]
        private IWebElement customMenu_viewAllPaymentPeriods;

        [FindsBy(How = How.Id, Using = "Viewallattainmentperiods43")]
        private IWebElement customMenu_viewAllAttainmentPeriods;



        public bool verifyMyBlitzMenu()
        {
            bool verifyMyBlitzMenu = false;
            bool verifyGlobalDashboard;
            bool verifySalesPersonDashboard;
            bool verifyPaidCommissions;
            bool verifyDueCommissions;
            bool verifySubmittedForApproval;
            bool verifyForecastedCommissions;
            bool verifyTeamDashboard;

            try
            {

                verifyMyBlitzMenu = myBlitzMenu.Displayed;

                if (verifyMyBlitzMenu == true)
                {
                    myBlitzMenu.Click();

                    verifyGlobalDashboard = myBlitzMenu_GlobalDashboard.Displayed;
                    verifyForecastedCommissions = myBlitzMenu_forecastedCommissions.Displayed;
                    verifyPaidCommissions = myBlitzMenu_paidCommissions.Displayed;
                    verifySalesPersonDashboard = myBlitzMenu_SalesPersonDashboard.Displayed;
                    verifySubmittedForApproval = myBlitzMenu_submittedForApproval.Displayed;
                    verifyTeamDashboard = myBlitzMenu_TeamDashboard.Displayed;
                    verifyDueCommissions = myBlitzMenu_dueCommissions.Displayed;

                    if (verifyTeamDashboard == true &&
                        verifySubmittedForApproval == true &&
                        verifySalesPersonDashboard == true &&
                        verifyPaidCommissions == true &&
                        verifyGlobalDashboard == true &&
                        verifyForecastedCommissions == true &&
                        verifyDueCommissions == true)
                    {
                        verifyMyBlitzMenu = true;
                    }
                    else
                    {
                        verifyMyBlitzMenu = false;
                    }
                }
                return verifyMyBlitzMenu;

            }
            catch (Exception)
            {

                return verifyMyBlitzMenu;
            }
        }
        public bool verifyCompensationPlansMenu()
        {
            bool verifyCompensationPlans = false;
            bool verifyCompensationPlan_ViewAll;
            bool verifyCompensationPlan_AddNewPlan;
            bool verifyCompensationPlan_ViewAllGoals;

            try
            {


                if (compensationPlansMenu.Displayed == true)
                {
                    compensationPlansMenu.Click();

                    verifyCompensationPlan_AddNewPlan = compensationPlans_addNewPlan.Displayed;
                    verifyCompensationPlan_ViewAll = compensationPlans_viewAll.Displayed;
                    verifyCompensationPlan_ViewAllGoals = compensationPlans_viewAllGoals.Displayed;

                    if (verifyCompensationPlan_AddNewPlan == true &&
                        verifyCompensationPlan_ViewAll == true &&
                        verifyCompensationPlan_ViewAllGoals == true)
                        verifyCompensationPlans = true;
                    else
                    {
                        verifyCompensationPlans = false;
                    }
                }
                return verifyCompensationPlans;
            }
            catch (Exception)
            {

                return verifyCompensationPlans;
            }
        }



        public bool verifyTransactionsMenu()
        {
            bool verifyTransactionsMenu = false;
            bool viewAllDeals;
            bool addNewDeal;
            bool viewAllAgentCharges;
            bool addNewAgentCharge;
            bool dealType;
            bool periods;
            bool dealSources;
            bool states;
            bool dealStatus;
            bool teams;
            bool companyRoles;
            bool tiers;

            try
            {


                if (transactionsMenu.Displayed == true)
                {
                    transactionsMenu.Click();
                    viewAllAgentCharges = transactions_ViewAllAgentCharges.Displayed;
                    viewAllDeals = transactions_ViewAllDeals.Displayed;
                    addNewDeal = transactions_AddNewDeal.Displayed;
                    addNewAgentCharge = transactions_AddNewAgentCharge.Displayed;
                    dealType = transactions_DealType.Displayed;
                    periods = transactions_Periods.Displayed;
                    dealSources = transactions_DealSource.Displayed;
                    states = transactions_States.Displayed;
                    dealStatus = transactions_DealStatus.Displayed;
                    teams = transactions_Teams.Displayed;
                    companyRoles = transactions_CompanyRoles.Displayed;
                    tiers = transactions_Tiers.Displayed;


                    if (viewAllAgentCharges == true &&
                        viewAllDeals == true &&
                        addNewDeal == true &&
                        addNewAgentCharge == true &&
                        dealType == true &&
                        periods == true &&
                        dealSources == true &&
                        states == true &&
                        dealStatus == true &&
                        teams == true &&
                        companyRoles == true &&
                        tiers == true)
                    {
                        verifyTransactionsMenu = true;
                    }
                    else
                    {
                        verifyTransactionsMenu = false;
                    }

                }

                return verifyTransactionsMenu;


            }
            catch (Exception)
            {

                return verifyTransactionsMenu;
            }
        }
        public bool verifyCommissionsMenu()
        {
            bool verifyCommissionsMenu = false;
            bool verifyPayCommissions;
            bool verifyViewHistory;

            try
            {


                if (commissionsMenu.Displayed == true)
                {
                    commissionsMenu.Click();
                    verifyPayCommissions = commissions_PayCommissions.Displayed;
                    verifyViewHistory = commissions_ViewHistory.Displayed;

                    if (verifyViewHistory == true && verifyPayCommissions == true)
                    {
                        verifyCommissionsMenu = true;
                    }
                    else
                    {
                        verifyCommissionsMenu = false;
                    }

                }

                return verifyCommissionsMenu;

            }
            catch (Exception)
            {

                return verifyCommissionsMenu;
            }
        }
        public bool verifyCustomMenu()
        {
            bool verifyCustomMenu = false;
            bool verifyViewAllUsers;
            bool verifyInviteNewUsers;
            bool verifyViewAllPaymentPeriods;
            bool verifyViewAllAttainmentPeriods;


            try
            {


                if (customMenu.Displayed == true)
                {
                    customMenu.Click();
                    verifyInviteNewUsers = customMenu_inviteNewUsers.Displayed;
                    verifyViewAllUsers = customMenu_viewAllUsers.Displayed;
                    verifyViewAllPaymentPeriods = customMenu_viewAllPaymentPeriods.Displayed;
                    verifyViewAllAttainmentPeriods = customMenu_viewAllAttainmentPeriods.Displayed;

                    if (verifyViewAllPaymentPeriods == true &&
                        verifyViewAllUsers == true &&
                        verifyInviteNewUsers == true &&
                        verifyViewAllAttainmentPeriods == true)
                    {
                        verifyCustomMenu = true;
                    }
                    else
                    {
                        verifyCustomMenu = false;
                    }
                }
                return verifyCustomMenu;

            }
            catch (Exception)
            {

                return verifyCustomMenu;
            }
        }

        public void SetKeywords(ArrayList keywords)
        {

            foreach (string keyword in keywords)
            {
                if (keyword.Contains(":"))
                {
                    String[] inputKeyword = keyword.Split(':');

                    if (inputKeyword[0].ToUpper() == "VERIFY")
                    {
                        switch (inputKeyword[1])
                        {
                            case "MyBlitz":
                                Assert.IsTrue(verifyMyBlitzMenu());
                                break;
                            case "CompensationPlans":
                                Assert.IsTrue(verifyCompensationPlansMenu());
                                break;
                            case "Transactions":
                                Assert.IsTrue(verifyTransactionsMenu());
                                break;
                            case "Commissions":
                                Assert.IsTrue(verifyCommissionsMenu());
                                break;
                            case "Custom":
                                Assert.IsTrue(verifyCustomMenu());
                                break;
                        }
                    }
                    if (inputKeyword[0].ToUpper() == "CLICK")
                    {
                        switch (inputKeyword[1])
                        {
                            case "MyBlitz":
                                myBlitzMenu.Click();
                                break;
                            case "GobalDashboard":
                                myBlitzMenu_GlobalDashboard.Click();
                                break;
                            case "TeamDashboard":
                                myBlitzMenu_TeamDashboard.Click();
                                break;
                            case "SalesPersonDashboard":
                                myBlitzMenu_SalesPersonDashboard.Click();
                                break;
                            case "PaidCommissions":
                                myBlitzMenu_paidCommissions.Click();
                                break;
                            case "ForecastedCommissions":
                                myBlitzMenu_forecastedCommissions.Click();
                                break;
                            case "DueCommissions":
                                myBlitzMenu_dueCommissions.Click();
                                break;
                            case "SubmittedForApproval":
                                myBlitzMenu_submittedForApproval.Click();
                                break;

                            case "CompensationPlans":
                                compensationPlansMenu.Click();
                                break;
                            case "ViewAll":
                                compensationPlans_viewAll.Click();
                                break;
                            case "AddNewPlan":
                                compensationPlans_addNewPlan.Click();
                                break;
                            case "ViewAllGoals":
                                compensationPlans_viewAllGoals.Click();
                                break;

                            case "Transactions":
                                transactionsMenu.Click();
                                break;

                            case "AddNewDeal":
                                transactions_AddNewDeal.Click();
                                break;

                            case "ViewAllDeals":
                                transactions_ViewAllDeals.Click();
                                break;

                            case "ViewAllAgentCharges":
                                transactions_ViewAllAgentCharges.Click();
                                break;

                            case "DealSource":
                                transactions_DealSource.Click();
                                break;

                            case "DealStatus":
                                transactions_DealStatus.Click();
                                break;

                            case "CompanyRoles":
                                transactions_CompanyRoles.Click();
                                break;

                            case "DealType":
                                transactions_DealType.Click();
                                break;
                            case "Periods":
                                transactions_Periods.Click();
                                break;
                            case "States":
                                transactions_States.Click();
                                break;
                            case "Teams":
                                transactions_Teams.Click();
                                break;
                            case "Tiers":
                                transactions_Tiers.Click();
                                break;

                            case "Commissions":
                                commissionsMenu.Click();
                                break;
                            case "PayCommissions":
                                commissions_PayCommissions.Click();
                                break;
                            case "ViewHistory":
                                commissions_ViewHistory.Click();
                                break;
                            case "Custom":
                                customMenu.Click();
                                break;
                            case "ViewAllUsers":
                                customMenu_viewAllUsers.Click();
                                break;
                            case "ViewAllPaymentPeriods":
                                customMenu_viewAllPaymentPeriods.Click();
                                break;
                            case "InviteNewUsers":
                                customMenu_inviteNewUsers.Click();
                                break;
                            case "ViewAllAttainmentPeriods":
                                customMenu_viewAllAttainmentPeriods.Click();
                                break;
                        }
                    }

                }
            }

        }

    }
}
