using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTest
{
    [TestFixture]
    public class BaseTest
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        [OneTimeSetUp]
        public void DriverSetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
        }

        [OneTimeTearDown]
        public void DriverTearDown()
        {
            driver.Quit();
        }
    }
}
