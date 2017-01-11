using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Blitz.Shared.Functions;

namespace Blitz.Shared.Functions
{
    public class OpenBrowser
    {

        public SharedFunctions sharedFunctions;
        ICapabilities desiredCapabilities;
        public IWebDriver Driver
        {
            get; set;
        }

        public OpenBrowser(string url, string browser ="Firefox")
        {

            switch (browser)
            {
                case "Firefox":
                    FirefoxProfile firefoxProfile = new FirefoxProfile();
                    firefoxProfile.AcceptUntrustedCertificates = true;
                    Driver = new FirefoxDriver(firefoxProfile);
                    Driver.Navigate().GoToUrl(url);
                    Driver.Manage().Window.Maximize();
                    break;
                case "Chrome":
                    Driver = new ChromeDriver();
                    Driver.Manage().Window.Maximize();
                    Driver.Manage().Cookies.DeleteAllCookies();
                    Driver.Navigate().GoToUrl(url);
                    break;
                case "Internet Explorer":
                    Driver = new InternetExplorerDriver();
                    Driver.Manage().Cookies.DeleteAllCookies();
                    Driver.Manage().Window.Maximize();
                    Driver.Navigate().GoToUrl(url);
                    break;
            }
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
 
    }
}
