using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTest
{
    public static class CustomConditions
    {
        public static Func<IWebDriver, IWebElement> Visible(IWebElement element)
        {
            return delegate (IWebDriver driver) {
                return element.Displayed ? element : null;
            };
        }

        public static Func<IWebDriver, bool> ListNthElementHasText(IList<IWebElement> elements, int index, string expectedText)
        {
            return delegate (IWebDriver driver) {
                bool result;
                try
                {
                    IWebElement element = elements[index];
                    result = element.Text.Contains(expectedText);
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            };
        }
        
    }
}
