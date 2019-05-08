using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using ElemCollection = System.Collections.ObjectModel.ReadOnlyCollection<OpenQA.Selenium.IWebElement>;

namespace BB_Assignment.pageObjects 
{
    public class HomePage : CommonUtilities
    {
        public string URL = "http://www.todolistme.net";

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.Driver = driver;
        }

        private readonly By _title = By.Id("title");
        private readonly By _newItemInput = By.Id("newtodo");
        private readonly By _deleteButton = By.ClassName("purge");
        private readonly By _toDoListItem = By.CssSelector("#mytodos li");
        private readonly By _toDoListItemCheckbox = By.CssSelector("#mytodos input");


        public void Navigate()
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public void AddListItem(string itemToAdd)
        {
            ClickElement(_newItemInput);
            SendKeys(_newItemInput, itemToAdd);
            UseEnterKey(_newItemInput);
        }

        public void MarkListItem() 
        {
            ClickElement(_toDoListItem);
        }

        public void MarkListItem(int index)
        {
            ClickElement(By.XPath(string.Format("//*[@id=\"todo_" + index + "\"]/input")));
        }

        public void RemoveAllListItems() 
        {
            ElemCollection elements = Driver.FindElements(_toDoListItem);
            int index = 0;

            foreach (var elem in elements)
            {
                ClickElement(_toDoListItemCheckbox);
                index++;
                System.Threading.Thread.Sleep(300);
            }

            ClickElement(_deleteButton);
        }

        public string[] GetAllListItems() 
        {
            string[] listItems = GetTexts(_toDoListItem);
            return listItems;
        }
    }
}
