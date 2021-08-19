
/*
 * Purpose : To validate the MS Server database using selenium .net
 * Author  : Sheetal Chaudhari
 * Date    : 17/08/2021
 */

using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBAutomation
{
    [TestClass]
    public class DBAutomation
    {
        public static SqlConnection conn = new SqlConnection();

        [TestInitialize]
        public void SetUp()
        {
            conn.ConnectionString = "Server=DESKTOP-SS5TGEM; Database=DBAutomation; Trusted_Connection=true";
        }

        [TestMethod]
        public void RetrivedTheData_FromDatabase()
        {
            conn.Open();
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM DBAutomation WHERE FirstColumn = @0", conn);
            selectCommand.Parameters.Add(new SqlParameter("0", 8));

            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                System.Diagnostics.Debug.WriteLine("FirstColumn\t\tSecond Column\t\tThird Column\t\tFourth Column\t");
                while (reader.Read())
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                                                       reader[0], reader[1], reader[2], reader[3]));
                }
            }
            conn.Close();
        }

        [TestMethod]
        public void InsertRecord_InTo_Database()
        {
            conn.Open();
            SqlCommand insertCommand = new SqlCommand("INSERT INTO DBAutomation (FirstColumn, SecondColumn, ThirdColumn, FourthColumn) VALUES (@0, @1, @2, @3)", conn);                    
               
                insertCommand.Parameters.Add(new SqlParameter("0","8"));
                insertCommand.Parameters.Add(new SqlParameter("1", "Evening Time"));
                insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
                insertCommand.Parameters.Add(new SqlParameter("3", "6"));

            int rows = insertCommand.ExecuteNonQuery();
            Assert.AreEqual(1, rows);
            conn.Close();
        }
    }
}

    

