using OpenQA.Selenium;
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

        private readonly By _newItemInput = By.Id("newtodo");
        private readonly By _deleteButton = By.ClassName("purge");
        private readonly By _toDoListItem = By.CssSelector("#mytodos li");
        private readonly By _doneToDoListItems = By.CssSelector("#mydonetodos li");
        private readonly By _doneProgressBar = By.Id("doneprogress");
        private readonly By _toDoProgressBar = By.Id("todoprogress");

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public string GetDoneProgressBarPercentage()
        {
            var element = Driver.FindElement(_doneProgressBar);
            string style = element.GetAttribute("style");

            return style;
        }

        public string GetToDoProgressBarPercentage()
        {
            var element = Driver.FindElement(_toDoProgressBar);
            string style = element.GetAttribute("style");

            return style;
        }

        public void AddListItem(string itemToAdd)
        {
            ClickElement(_newItemInput);
            SendKeys(_newItemInput, itemToAdd);
            UseEnterKey(_newItemInput);
        }

        public void MarkListItem(int index)
        {
            ClickElement(By.XPath(string.Format("//*[@id=\"todo_" + index + "\"]/input")));
            System.Threading.Thread.Sleep(500);
        }

        public void RemoveAllListItems() 
        {
            ElemCollection elements = Driver.FindElements(_toDoListItem);
            int index = 0;

            foreach (var elem in elements)
            {
                MarkListItem(index);
                index++;
                System.Threading.Thread.Sleep(300);
            }

            ClickElement(_deleteButton);
        }

        public string[] GetAllDoneListItems()
        {
            string[] listItems = GetTexts(_doneToDoListItems);
            return listItems;
        }

        public string[] GetAllActiveListItems() 
        {
            string[] listItems = GetTexts(_toDoListItem);
            return listItems;
        }
    }
}
