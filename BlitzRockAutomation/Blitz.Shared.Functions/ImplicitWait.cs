using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Blitz.Shared.Functions
{
    public class ImplicitWait
    {
        public ImplicitWait(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebDriver driver { get; set; }

        public IWebElement FindElement(By by, int seconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                var element = wait.Until(c =>
                {
                    var elements = driver.FindElements(by);
                    if (elements.Count > 0)
                        return elements[0];
                    return null;
                });

                return element;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
