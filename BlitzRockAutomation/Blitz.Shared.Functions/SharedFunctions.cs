using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.IO;
using System.Net.Mail;

namespace Blitz.Shared.Functions
{
    public class SharedFunctions
    {
        static Random random = new Random();
        #region Random string Generator
        /// <summary>
        /// Function to generate a random string
        /// </summary>
        /// <param name="size"></param>
        /// <param name="lowerCase"></param>
        /// <returns></returns>
        public string RandomString(int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        #endregion Random String Generator

        public IWebDriver driver { get; set; }
        /// <summary>
        /// Method to wait for an already defined element by IWebElement
        /// </summary>
        /// <param name="element"></param>
        public void WaitForCondition(IWebElement element, int seconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(seconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(driver => element.Displayed);
        }

        public void createTestLog(string testCasePath, string text = "Test Case Execution Steps")
        {

            if (!File.Exists(testCasePath))
            {
                using (StreamWriter streamWriter = File.CreateText(testCasePath))
                    streamWriter.WriteLine("====== Test Case:" + text + " ======");
              

            }
            else if (File.Exists(testCasePath))
            {
                TextWriter textWriter = new StreamWriter(testCasePath,true);
                textWriter.WriteLine(text);
                textWriter.Close();
            }
        }

        public bool readTestLog(string testCasePath)
        {
            bool validationFlag;
            int counter = 0;
            int failureCounter = 0;
            int passCounter = 0;
            int executedSteps = 0;
            string line;
            validationFlag = true;
            // Read the file and display it line by line.
            StreamReader file = new StreamReader(testCasePath);
            while ((line = file.ReadLine()) != null)
            {
                
                counter++;
                if (line.Contains("FAIL"))
                {
                    validationFlag = false;
                    failureCounter = failureCounter + 1;
                }
                if (line.Contains("PASS"))
                {
                    passCounter = passCounter + 1;
                }

            }
            executedSteps  = counter - 1;
            file.Close();
            TextWriter textWriter = new StreamWriter(testCasePath, true);
            textWriter.WriteLine("Executed Steps:"+ executedSteps +" Steps Failed:" + failureCounter+ " Successful Steps:"+ passCounter);
            textWriter.Close();
 
            return validationFlag;

        }

        public void createGlobalLog(string globalLogPath, int passedTests,int failedTests)
        {
            int totalTests = passedTests + failedTests;
            if (!File.Exists(globalLogPath))
            {
                using (StreamWriter streamWriter = File.CreateText(globalLogPath))
                    streamWriter.WriteLine("<!DOCTYPE html> " +
                      "<html>"+
                      "<body style=background - color:white;>"+
                      "<h1 style=color:blue;><center>Blitz Business Trial</center></h1>" +
                      "<h1 style=color:blue;><center>Tests Execution Report</center></h1>" +
                      "<style>" +
                      "table {font - family: arial, sans - serif;border - collapse: collapse;width: 100 %;}" +
                      "td, th {border: 2px solid #dddddd;text - align: left;padding: 8px;}" +
                      "tr: nth - child(even) { background - color: white; }" +
                      "</style> " +
                      "<center>" +
                      "<table style = width:50%>" +
                      "<caption><b> Executed Tests </b></caption>" +
                      "<tr>" +
                      "<td><b> Passed </b></td>" +
                      "<td bgcolor=green><b>" + passedTests + "</b></td>" +
                      "</tr>" +
                      "<tr>" +
                      "<td><b> Failed </b></td>" +
                      "<td bgcolor=red><b>" + failedTests + "</b></td>" +
                      "</tr>" +
                      "<tr>" +
                      "<td><b>Total</b></td>" +
                      "<td><b>" + totalTests + "</b></td>"+
                      "</tr>" +
                      "</table>" +
                      "</center>"+
                      "<br>"+
                      "<br>");



            }
            

            else if (File.Exists(globalLogPath))
            {
                TextWriter textWriter = new StreamWriter(globalLogPath, true);
                textWriter.Close();
            }

        }

        public void SendResults(string report)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.sendgrid.net");

                mail.From = new MailAddress("noreply@blitzrocks.com");
                mail.To.Add("Hector.oyervides@definityfirst.com");
                mail.Subject = "BlitzRock Automation Report.";

                mail.IsBodyHtml = true;
                string htmlBody;

                string getHTML = File.ReadAllText(report);

                htmlBody = getHTML;

                mail.Body = htmlBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("azure_a183a7f6efc909dd23e67f9e02d41411@azure.com", "m8vz7\\)EUuhq~7hK");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

      
    }
}
