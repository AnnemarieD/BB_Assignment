using System;
using System.Collections.Generic;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BB_Assignment.pageObjects;
using System.Reflection;
using System.IO;

namespace BB_Assignment.specs 
{
    public class AddListItemTests : IDisposable 
    {
        public IWebDriver Driver;
        public HomePage HomePage;

        public AddListItemTests() 
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            HomePage = new HomePage(Driver);
        }

        [Fact(DisplayName = "I can successfully add one item to the list")]
        public void AddOneItemToTheList() 
        {
            // Arrange
            HomePage.Navigate();
            HomePage.RemoveAllListItems();

            // Act
            HomePage.AddListItem("Start testing");
            var actualList = HomePage.GetAllListItems();
            string[] expectedList = new string[]
            {
                "Start testing"
            };

            // Assert
            Assert.Equal(expectedList, actualList);
        }

        [Fact (DisplayName = "I can successfully add multiple items to the list")]
        public void AddMultipleItemsToTheList()
        {
            // Arrange
            HomePage.Navigate();
            HomePage.RemoveAllListItems();

            // Act
            HomePage.AddListItem("Can I add some code here as well?");
            HomePage.AddListItem("No I can't!%$#>");
            var actualList = HomePage.GetAllListItems();
            string[] expectedList = new string[]
            {
                "Can I add some code here as well?",
                "No I can't!%$#>"
            };

            // Assert
            Assert.Equal(expectedList, actualList);
        }

        public void Dispose() {
            Driver.Quit();
        }
    }
}
