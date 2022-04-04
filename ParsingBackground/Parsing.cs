using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Opera;

namespace ParsingBackground
{
    internal class Parsing
    {
        /// <summary>
        /// Метод запускающий бразуер и Chome Driver
        /// </summary>
        public void startBrowser()
        {
            var driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory + "\\parserFiles\\chromeFiles");
            driver.Manage().Window.Maximize();
            Searching(driver);
        }

        /// <summary>
        /// Метод, который является основной частью парсера
        /// </summary>
        /// <param name="driver"></param>
        public void Searching(ChromeDriver driver)
        {

            driver.Url = "https://smev3.gosuslugi.ru/portal/inquirytype.jsp?zone=fed";
            System.Threading.Thread.Sleep(5000);

            IWebElement max = driver.FindElement(By.XPath("//*[@id='news_0']/ul/li[12]/a"));
            int maximum = Convert.ToInt32(max.Text);


            for (int k = 0; k < maximum; k++)
            {

                IWebElement rightArrow = driver.FindElement(By.ClassName("fa-angle-right"));

                var nameTable = driver.FindElements(By.ClassName("cellOwner"));

                var targetTable = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[2]"));

                var identifierTable = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[3]"));

                var scopeOfDataTable = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[4]"));

                var versionTable = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[5]"));

                var mpVersionTable = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[6]"));

                var registrationDateTable = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[7]"));

                var linkTable = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[1]/a"));

                List<ParsedData> resultData = new List<ParsedData>();

                for (int i = 0; i < nameTable.Count; i++)
                {

                    resultData.Add(new ParsedData
                    {
                        Name = nameTable[i].Text,
                        Target = targetTable[i].Text,
                        Identifier = identifierTable[i].Text,
                        ScopeOfData = scopeOfDataTable[i].Text,
                        Version = versionTable[i].Text,
                        MPVersion = mpVersionTable[i].Text,
                        RegistrationDate = registrationDateTable[i].Text,
                        Link = linkTable[i].GetAttribute("href"),
                    });
                }

                rightArrow = driver.FindElement(By.ClassName("fa-angle-right"));
                rightArrow.Click();
                System.Threading.Thread.Sleep(3000);
            }




            driver.Navigate().GoToUrl("https://smev3.gosuslugi.ru/portal/inquirytype.jsp?zone=reg");
            System.Threading.Thread.Sleep(5000);

            IWebElement maxReg = driver.FindElement(By.XPath("//*[@id='news_0']/ul/li[12]/a"));
            int maximumReg = Convert.ToInt32(maxReg.Text);
            Console.WriteLine(maximumReg);

            for (int k = 0; k < maximumReg; k++)
            {

                IWebElement rightArrow = driver.FindElement(By.ClassName("fa-angle-right"));

                var nameTableReg = driver.FindElements(By.ClassName("cellOwner"));

                var targetTableReg = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[2]"));


                var identifierTableReg = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[3]"));

                var scopeOfDataTableReg = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[4]"));

                var versionTableReg = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[5]"));

                var mpVersionTableReg = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[6]"));

                var registrationDateTableReg = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[7]"));

                var linkTableReg = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div/div/table/tbody/tr/td[1]/a"));

                List<ParsedData> resultDataReg = new List<ParsedData>();

                for (int i = 0; i < nameTableReg.Count; i++)
                {

                    resultDataReg.Add(new ParsedData
                    {
                        Name = nameTableReg[i].Text,
                        Target = targetTableReg[i].Text,
                        Identifier = identifierTableReg[i].Text,
                        ScopeOfData = scopeOfDataTableReg[i].Text,
                        Version = versionTableReg[i].Text,
                        MPVersion = mpVersionTableReg[i].Text,
                        RegistrationDate = registrationDateTableReg[i].Text,
                        Link = linkTableReg[i].GetAttribute("href"),
                    });
                }

                rightArrow = driver.FindElement(By.ClassName("fa-angle-right"));
                rightArrow.Click();
                System.Threading.Thread.Sleep(3000);
            }

        }

    }
}
