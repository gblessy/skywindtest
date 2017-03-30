using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace GmailTest
{
    
    class GmailPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        By loginLocator = By.Id("Email");

        By passwordLocator = By.Id("Passwd");
   
        By compose = By.XPath("//*[contains(text(), 'COMPOSE')]");

        By to = By.Name("to");

        By subjectbox = By.Name("subjectbox");

        By sendButton = By.XPath("//*[contains(text(), 'Send')]");
     
        By sentMailLink = By.XPath("//*[contains(text(), 'Sent Mail')]");

        By Email = By.CssSelector("[role = main] .zA:nth-of-type(1)");

        public GmailPage(IWebDriver driver)
            {
                this.driver = driver;
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            }

        public void Open()
            {
                driver.Navigate().GoToUrl("http://gmail.com");
            }

        public void EnterLogin(String login)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(loginLocator));
            driver.FindElement(loginLocator).SendKeys(login);
            driver.FindElement(loginLocator).SendKeys(Keys.Enter);
        }

        public void EnterPassword(String passwd)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(passwordLocator));
            driver.FindElement(passwordLocator).SendKeys(passwd);
            driver.FindElement(passwordLocator).SendKeys(Keys.Enter);
        }

        internal void Login(String userName, String password)
        {
            EnterLogin(userName);
            EnterPassword(password);
           
        }

        public void ElementClick(By element)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element)).Click();
        }

        public void ElementSendKeys(By element, String text)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element)).SendKeys(text);
        }

        internal void SendMail(string userName, string subject)
        {
            ElementClick(compose);
            ElementSendKeys(to, userName);
            ElementSendKeys(subjectbox, subject);
            ElementClick(sendButton);

        }

        internal void GoToSent()
        {
            ElementClick(sentMailLink);
    
        }

        internal void AssertEmailIsPresent(string subject)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(Email, subject));     
        }

        public void Close()
        {
            driver.Quit();
        }

    }
}

