using System;
using System.Collections.Generic;
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
        ParsedData set;
        //Parsing(DataSet _set)
        //{
        //    set = _set;
        //}

        public void startBrowser()
        {
            var driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory + "\\parserFiles\\chromeFiles");
            driver.Manage().Window.Maximize();
            Searching(driver);
        }

        public void Searching(ChromeDriver driver)
        {
            for (int k = 0; k < 5; k++)
            {


                driver.Url = "https://smev3.gosuslugi.ru/portal/inquirytype.jsp?zone=fed";
                System.Threading.Thread.Sleep(5000);

                IWebElement rightArrow = driver.FindElement(By.XPath("//*[@id='news_0']/ul/li[13]/a"));

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

                for (int i = 0; i < resultData.Count; i++)
                {
                    Console.WriteLine(resultData[i].Name);
                    Console.WriteLine(resultData[i].Link);
                }

                rightArrow = driver.FindElement(By.XPath("//*[@id='news_0']/ul/li[13]/a"));
                rightArrow.Click();
                System.Threading.Thread.Sleep(3000);
            }

        }

    }
}
