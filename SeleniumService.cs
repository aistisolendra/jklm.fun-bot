using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace wordguesser
{
    public class SeleniumService
    {
        private readonly WebDriver _driver;

        public SeleniumService(string goToUrl)
        {
            _driver = CreateWebDriver(goToUrl);
        }

        public WebDriver CreateWebDriver(string goToUrl)
        {
            var driver = new ChromeDriver()
            {
                Url = goToUrl
            };

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6000);

            return driver;
        }

        public void SwitchToFrame()
        {
            _driver.SwitchTo()
                .Frame(_driver.FindElement(By.XPath("//div[@class='game']/iframe[contains(@src,'jklm.fun')]")));
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public IWebElement FindElementByClassName(string className)
        {
            return _driver.FindElement(By.ClassName(className));
        }

        public IWebElement FindElementByXPath(string xPath)
        {
            return _driver.FindElement(By.XPath(xPath));
        }

        public IWebElement FindElementByCssSelector(string cssSelector)
        {
            return _driver.FindElement(By.CssSelector(cssSelector));
        }

        public IWebElement FindElementByMultipleCssSelectors(string cssSelectors)
        {
            return _driver.FindElement(By.CssSelector($"div[class*='{cssSelectors}']"));
        }

        public IWebElement FindElementByName(string name)
        {
            return _driver.FindElement(By.Name(name));
        }

        public IWebElement FindElementByTagName(string tagName)
        {
            return _driver.FindElement(By.TagName(tagName));
        }

        public IWebElement FindElementById(string id)
        {
            return _driver.FindElement(By.Id(id));
        }

        public IWebElement FindElementByText(string text)
        {
            return _driver.FindElement(By.XPath($"//*[contains(text(), '{text}')]"));
        }

        public bool IsPlayerTurn()
        {
            var playerTurnElement = FindElementByClassName("selfTurn");

            return playerTurnElement.Displayed;
        }

        public void LoginWithName(string name)
        {
            var nameInput = FindElementByClassName("nickname");
            nameInput.SendKeys(name);

            var loginButton = FindElementByText("OK");
            loginButton.Click();
        }

        public void JoinGame()
        {
            var joinGameButton = FindElementByClassName("join");
            joinGameButton.FindElement(By.TagName("button")).Click();
        }

        public string GetSyllable()
        {
            var syllableElement = FindElementByClassName("syllable");

            return syllableElement.Text;
        }

        public void SubmitWord(string word)
        {
            var inputElement = FindElementByClassName("selfTurn");

            var input = inputElement.FindElement(By.TagName("input"));

            input.SendKeys(word);
            input.SendKeys(Keys.Enter);
        }
    }
}
