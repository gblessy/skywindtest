using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using static GmailTest.Configuration;



namespace GmailTest
{
        using static ExpectedConditions;

        namespace Selenium_PageObjects
        {
        using static CustomConditions;

            [TestFixture]
            public class GmailTest : BaseTest
            {
                GmailPage gmailPage;

                [OneTimeSetUp]
                public void Init()
                {
                    gmailPage = new GmailPage(driver);
                }

                [Test]
                public void GmailSendEmailTest()
                {

                Random random = new Random();
                int mailRandomizer = random.Next(100);
                 String subject = "TestEmail" + mailRandomizer;


                    gmailPage.Open();
                    gmailPage.Login(userName, password);
                    gmailPage.SendMail(userName, subject);
                    gmailPage.GoToSent();
                    gmailPage.AssertEmailIsPresent(subject);

                }

            }

        }
    }
