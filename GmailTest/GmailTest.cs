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

            [TestFixture]
            public class GmailTest 
            
            {
                private BaseTest start = BaseTest.getDriver();
                
                GmailPage gmailPage;
                String subject;

                [OneTimeSetUp]
                public void Init()
                {
                    gmailPage = new GmailPage(start.DriverSetUp());
                    subject = GenerateSubject();
                    
                }
                

                [Test]
                public void GmailSendEmailTest()
                {
                    gmailPage.Open();
                    gmailPage.Login(userName, password);
                    gmailPage.SendMail(userName, subject);
                    gmailPage.GoToSent();
                    gmailPage.AssertEmailIsPresent(subject);
                    gmailPage.Close();
                }

            }

        }
    
