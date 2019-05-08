using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ElemCollection = System.Collections.ObjectModel.ReadOnlyCollection<OpenQA.Selenium.IWebElement>;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BB_Assignment
{
    public class CommonUtilities 
    {
        public IWebDriver Driver;
        public WebDriverWait Wait;

        public CommonUtilities(IWebDriver driver) 
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ClickElement(By selector) 
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(selector)).Click();
        }

        public void UseEnterKey(By selector) 
        {
            Driver.FindElement(selector).SendKeys(Keys.Enter);
        }

        public void SendKeys(By selector, string keys) 
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(selector)).SendKeys(keys);
        }

        /// <summary>
        /// Gets the text values of a list of element(s) with an unknown number of elements
        /// and saves these in a string array
        /// </summary>
        /// <returns>An string array with texts from a collection of elements</returns>
        /// <param name="selector">selector</param>
        public string[] GetTexts(By selector) 
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(selector));

            ElemCollection elements = Driver.FindElements(selector);
            string[] texts = new string[elements.Count];
            int index = 0;

            foreach (var item in elements) 
            {
                var text = item.Text;
                texts.SetValue(text, index);
                index++;
            }

            return texts;
         }
    }
}
