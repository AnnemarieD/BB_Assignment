using System;
using System.IO;
using System.Reflection;
using BB_Assignment.pageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace BB_Assignment.specs
{
    public class ProgessBarTests : IDisposable
    {
        public IWebDriver Driver;
        public HomePage HomePage;

        public ProgessBarTests()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            HomePage = new HomePage(Driver);
        }

        [Fact (DisplayName = "The 'done' progress bar shows 50% when 5/10 list items are marked as done")]
        public void DoneProgressBarShowsFiftyPercentDone()
        {
            // Arrange
            // Situation to create: there are 10 list items on the to do list
            HomePage.Navigate();
            HomePage.AddListItem("8th list item");
            HomePage.AddListItem("9th list item");
            HomePage.AddListItem("10th list item");

            // Act
            HomePage.MarkListItem(0);
            HomePage.MarkListItem(1);
            HomePage.MarkListItem(2);
            HomePage.MarkListItem(3);
            HomePage.MarkListItem(4);
            string actualString = HomePage.GetDoneProgressBarPercentage();
            string expectedDoneProgressBarPercentage = "50%";

            // Assert
            Assert.Contains(expectedDoneProgressBarPercentage, actualString);
        }

        [Fact(DisplayName = "The 'to do' progress bar shows 30% when 3/10 list items are marked as done")]
        public void ActiveProgressBarShowsFiftyPercentDone()
        {
            // Arrange
            // Situation to create: there are 10 list items on the to do list
            HomePage.Navigate();
            HomePage.AddListItem("8th list item");
            HomePage.AddListItem("9th list item");
            HomePage.AddListItem("10th list item");

            // Act
            HomePage.MarkListItem(7);
            HomePage.MarkListItem(8);
            HomePage.MarkListItem(9);
            string actualString = HomePage.GetToDoProgressBarPercentage();
            string expectedToDoProgressBarPercentage = "30%";

            // Assert
            Assert.Contains(expectedToDoProgressBarPercentage, actualString);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
