
/*
 * Purpose : To validate the MS Server database using selenium .net
 * Author  : Sheetal Chaudhari
 * Date    : 17/08/2021
 */

using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DBAutomation
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver driver = new ChromeDriver();
        public static IWebElement username, password, loginBtn;

        [TestMethod]
        public void RetrivedTheData_FromDatabase()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=DESKTOP-SS5TGEM; Database=DBAutomation; Trusted_Connection=true";
            conn.Open();

            //Selenium
            setUp();
            SqlCommand command = new SqlCommand("SELECT TOP (1) [FirstColumn] FROM DBAutomation", conn);
            SqlDataReader reader1;

            using (reader1 = command.ExecuteReader())
            {
                Assert.IsNotNull(reader1);
                while (reader1.Read())
                {
                   username.SendKeys(reader1.GetString(0));
                }
            }
            password.SendKeys("Your password");
            loginBtn.Click();
            driver.Close();
        }

        [TestMethod]
        public void InsertRecord_InDatabase()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=DESKTOP-SS5TGEM; Database=DBAutomation; Trusted_Connection=true";
            conn.Open();

            SqlCommand insertCommand = new SqlCommand("INSERT INTO DBAutomation (FirstColumn, SecondColumn, ThirdColumn, FourthColumn) VALUES (@0, @1, @2, @3)", conn);

                insertCommand.Parameters.Add(new SqlParameter("0","5"));
                insertCommand.Parameters.Add(new SqlParameter("1", "Test Column4"));
                insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
                insertCommand.Parameters.Add(new SqlParameter("3", "0"));

            int rows = insertCommand.ExecuteNonQuery();
            Assert.AreEqual(1, rows);
        }
        static void setUp()
        {
            driver.Url = "https://www.flipkart.com/";
            driver.Manage().Window.FullScreen();
           
            username = driver.FindElement(By.XPath("//input[@class='_2IX_2- VJZDxU']"));
            password = driver.FindElement(By.XPath("//input[@class='_2IX_2- _3mctLh VJZDxU']"));
            loginBtn = driver.FindElement(By.XPath("//button[@class='_2KpZ6l _2HKlqd _3AWRsL']"));
        }
    }
}

    

