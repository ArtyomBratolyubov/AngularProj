using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void AddImg()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:51489/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("galleryBtn")).Click();
            driver.FindElement(By.Id("addImgBtn")).Click();

            driver.FindElement(By.Id("urlInput")).SendKeys("https://lh4.ggpht.com/wKrDLLmmxjfRG2-E-k5L5BUuHWpCOe4lWRF7oVs1Gzdn5e5yvr8fj-ORTlBF43U47yI=w300");
            driver.FindElement(By.Id("nameInput")).SendKeys("test");

            driver.FindElement(By.Id("addImgBtn")).Click();
        }

        [Test]
        public void EditDescription()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://localhost:51489/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("editBtn")).Click();

            driver.FindElement(By.Id("descTextArea")).SendKeys("Test!");

            driver.FindElement(By.Id("saveBtn")).Click();
        }

    }
}
