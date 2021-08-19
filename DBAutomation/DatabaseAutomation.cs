
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
            int totalRows = Utility.Utility.readData(conn);
            Assert.AreEqual(5, totalRows);
            conn.Close();
        }

        [TestMethod]
        public void InsertRecord_InTo_Database()
        {
            conn.Open();
            int noOfRowsAdded= Utility.Utility.insertData_intoDB(conn);
            Assert.AreEqual(1, noOfRowsAdded);
            Utility.Utility.readData(conn);
            conn.Close();
        }
    }
}

    

