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
        private static BaseTest instance = null;
        private IWebDriver driver;

        private BaseTest() { }

        public IWebDriver DriverSetUp()
        {
            driver = new ChromeDriver();
            return driver;
        }

        public static BaseTest getDriver()
        {
            if (instance == null)
            {
                instance = new BaseTest();
            }
            return instance;
        }
        
    }
}
