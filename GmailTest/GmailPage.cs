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
    
    using static GmailTest.CustomConditions;
    class GmailPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement loginEmail;

        [FindsBy(How = How.Id, Using = "Passwd")]
        public IWebElement loginPassword;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'COMPOSE')]")]
        public IWebElement compose;

        [FindsBy(How = How.Name, Using = "to")]
        public IWebElement to;

        [FindsBy(How = How.Name, Using = "subjectbox")]
        public IWebElement subjectbox;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Send')]")]
        public IWebElement sendButton;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Sent Mail')]")]
        public IWebElement sentMailLink;

        [FindsBy(How = How.CssSelector, Using = "[role = main] .zA")]
        IList<IWebElement> Emails;

        public GmailPage(IWebDriver driver)
            {
                this.driver = driver;
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
                PageFactory.InitElements(driver, this);
            }

        public void Open()
            {
                driver.Navigate().GoToUrl("http://gmail.com");
            }

        internal void Login(String userName, String password)
        {
            wait.Until(Visible(loginEmail)).SendKeys(userName);
            loginEmail.SendKeys(Keys.Enter);

            wait.Until(Visible(loginPassword)).SendKeys(password);
            loginPassword.SendKeys(Keys.Enter);

        }

        internal void SendMail(string userName, string subject)
        {
            wait.Until(Visible(compose)).Click();
            wait.Until(Visible(to)).SendKeys(userName);
            wait.Until(Visible(subjectbox)).SendKeys(subject);
            wait.Until(Visible(sendButton)).Click();
        }

        internal void GoToSent()
        {
            wait.Until(Visible(sentMailLink)).Click();
        }

        internal void AssertEmailIsPresent(string subject)
        {
            wait.Until(ListNthElementHasText(Emails, 0, subject));
        }

    }
}

