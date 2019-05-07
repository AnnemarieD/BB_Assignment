using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using ElemCollection = System.Collections.ObjectModel.ReadOnlyCollection<OpenQA.Selenium.IWebElement>;

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

        public bool IsClickable(By selector) 
        {
            var element = Driver.FindElement(selector);
            return element.Enabled;
        }

        public void SendKeys(By selector, string keys) 
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(selector)).SendKeys(keys);
        }

        public bool IsDisplayed(By selector) 
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(selector)).Displayed;
        }

        public void Clear(By selector) 
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(selector)).Clear();
        }

        public string GetText(By selector) 
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(selector));

            var element = Driver.FindElement(selector);
            string text = element.Text;

            return text;
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

    public static class CreateRandomString 
    {
        private static readonly Random _random = new Random();

        public static string RandomString(int length) 
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
