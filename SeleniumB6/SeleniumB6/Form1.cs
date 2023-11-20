using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace SeleniumB6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string defaultUrl = "http://vnexpress.net/";

        // 85_TrongNhan

        private void btn1_Click(object sender, EventArgs e)
        {
            // open url by 85_TrongNhan
            IWebDriver driver = new ChromeDriver();
            string url = txt1.Text.ToString();
            if (url == "" ) { driver.Navigate().GoToUrl(defaultUrl); }
            else {  driver.Navigate().GoToUrl(url);}

            // get url by 85_TrongNhan
            String link_hentai = driver.Url;
            Console.WriteLine(link_hentai);

            // get page source 85_TrongNhan
            String PageSource = driver.PageSource;
            Console.WriteLine(PageSource);

            // close command window by 85_TrongNhan
            ChromeDriverService chrome = ChromeDriverService.CreateDefaultService();
            chrome.HideCommandPromptWindow = true;

            // direct path of web by 85_TrongNhan
            driver.Navigate().GoToUrl("http://google.com");
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            driver.Navigate().Refresh();

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            // close web by 85_TrongNhan
            driver.Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            // quit web by 85_TrongNhan
            driver.Quit();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            // get Title then display in display textbox by 85_TrongNhan
            string urlTitle = driver.Title;
            txt2.Text = urlTitle.ToString();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            // send key by 85_TrongNhan
            String url = txt3.Text;
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys(url.ToString());
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            // send key input account password by 85_TrongNhan
            String acc = txt4.Text;
            String pass = txt5.Text;
            IWebElement e_email = driver.FindElement(By.Name("email"));
            IWebElement passW = driver.FindElement(By.Name("pass"));
            IWebElement e_login = driver.FindElement(By.Name("login"));
            e_email.SendKeys(acc.ToString());
            passW.SendKeys(pass.ToString());
            e_login.Click();
        }
    }
}
