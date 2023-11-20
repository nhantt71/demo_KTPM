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

namespace SeleniumDemoProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            string url = txB1.Text.ToString();
            if(url == "")
                driver.Navigate().GoToUrl("http://vnexpress.net"); //trong nhan - 85
            else
                driver.Navigate().GoToUrl(url);


            //driver.Close();

            //tat man hinh den
            ChromeDriverService chrome = ChromeDriverService.CreateDefaultService();
            chrome.HideCommandPromptWindow = true;
            //dieu huong trinh duyet
            IWebDriver driver1 = new ChromeDriver(chrome);

            //dong moi cua so lien ket
            //driver.Quit();

            //lay url 
            String link_hientai = driver.Url;
            Console.WriteLine(link_hientai);

            //lay title
            string urlTitle = driver.Title;
            Console.WriteLine(urlTitle);
            txB1.Text = urlTitle.ToString();

            //lay pagesource
            String pageSource = driver.PageSource;
            Console.WriteLine(pageSource);

            //dieu huong trang
            driver.Navigate().GoToUrl("https://ou.edu.vn/");
            Thread.Sleep(2000);
            driver.Navigate().Back();
            Thread.Sleep(2000);
            driver.Navigate().Forward();// 85 - to trong nhan - nay gio em quen comment ten voi stt

        }
    }
}
