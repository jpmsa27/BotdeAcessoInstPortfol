using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace BotdeAcessoPotfol
{
    class Program
    {
        static void Main(string[] args)
        {
            //Coloque seus dados.
            string usuario = "usuario";
            string senha = "senha";
            string Localdaimagem = @"C:\";
            string Localdotexto = File.ReadAllText(@"C:\");


            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.EnableMobileEmulation("Pixel 2");
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            driver.Navigate().GoToUrl("https://www.instagram.com");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button[class='sqdOP  L3NKy   y3zKF     ']")).Click();
            driver.FindElement(By.Name("username")).SendKeys(usuario);
            driver.FindElement(By.Name("password")).SendKeys(senha);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[class='sqdOP yWX7d    y3zKF     ']")).Click();
            Thread.Sleep(2000);
           
            //Try catch usado para não dar erro caso algum pop-up não apareça.
            try
            {
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("button[class='aOOlW   HoLwm ']")).Click();
            }
            catch
            {
                driver.FindElement(By.CssSelector("div[class='q02Nz _0TPg']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("div[class='q02Nz _0TPg']")).SendKeys(Localdaimagem);

            }
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("div[class='q02Nz _0TPg']")).Click();

            driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(Localdaimagem);
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("button[class='pHnkA']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("button[class='UP43G']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("textarea[class='_472V_']")).SendKeys(Localdotexto);
            Thread.Sleep(1000);
            
            //Essas ultimas linhas são para o envio automatico da imagem.

            //driver.FindElement(By.CssSelector("button[class='UP43G']")).Click();
            //Thread.Sleep(2000);
            //driver.Quit();
        }
    }
}
