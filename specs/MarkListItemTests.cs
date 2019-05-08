using System;
using System.IO;
using System.Reflection;
using BB_Assignment.pageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace BB_Assignment.specs
{
    public class MarkListItemTests : IDisposable 
    {
        public IWebDriver Driver;
        public HomePage HomePage;

        public MarkListItemTests() 
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            HomePage = new HomePage(Driver);
        }

        [Fact (DisplayName = "I can successfully mark one item as 'done'")]
        public void MarkOneListItem() 
        {
            // Arrange
            HomePage.Navigate();

            // Act
            HomePage.MarkListItem(3);
            int actualNumberOfActiveListItems = HomePage.GetAllListItems().Length;
            int expectedNumberOfActiveListItems = 6;

            // Assert
            Assert.Equal(expectedNumberOfActiveListItems, actualNumberOfActiveListItems);
        }

        [Fact (DisplayName = "I can successfully mark multiple items as 'done'")]
        public void MarkMultipleListItems() 
        {
            // Arrange
            // Act
            // Assert
        }

        public void Dispose() {
            Driver.Quit();
        }

    }
}
