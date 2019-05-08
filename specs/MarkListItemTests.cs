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
            int actualNumberOfActiveListItems = HomePage.GetAllActiveListItems().Length;
            int expectedNumberOfActiveListItems = 6;

            // Assert
            Assert.Equal(expectedNumberOfActiveListItems, actualNumberOfActiveListItems);
        }

        [Fact (DisplayName = "I can successfully mark multiple items as 'done'")]
        public void MarkMultipleListItems() 
        {
            // Arrange
            // Situation to create: there are 10 list items on the to do list
            HomePage.Navigate();
            HomePage.AddListItem("8th list item");
            HomePage.AddListItem("9th list item");
            HomePage.AddListItem("10th list item");

            // Act
            HomePage.MarkListItem(0);
            HomePage.MarkListItem(9);
            HomePage.MarkListItem(6);
            HomePage.MarkListItem(1);
            HomePage.MarkListItem(4);
            var actualListOfDoneListItems = HomePage.GetAllDoneListItems();
            string[] expectedListOfDoneListItems = new string[]
            {
                "Drag the list, Example template, over this lists title above.",
                "All changes are saved locally, automatically.",
                "All done. Tick all the items off then hit the trash icon below.",
                "10th list item",
                "Howdy. Let's get you up and running."
            };

            // Assert
            Assert.Equal(expectedListOfDoneListItems, actualListOfDoneListItems);
        }

        public void Dispose() 
        {
            Driver.Quit();
        }

    }
}
