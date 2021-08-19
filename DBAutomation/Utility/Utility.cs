using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DBAutomation.Utility
{
    class Utility
    {
        public static int readData(SqlConnection conn)
        {
            int rowCount = 0;
            /*SqlCommand selectCommand = new SqlCommand("SELECT * FROM DBAutomation WHERE FirstColumn = @0", conn);
            selectCommand.Parameters.Add(new SqlParameter("0", 8));*/
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM DBAutomation", conn);

            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                System.Diagnostics.Debug.WriteLine("FirstColumn\t\tSecond Column\t\tThird Column\t\tFourth Column\t");
                while (reader.Read())
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                                                       reader[0], reader[1], reader[2], reader[3]));
                    rowCount++;
                }
            }
            return rowCount;
        }

        public static int insertData_intoDB(SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO DBAutomation (FirstColumn, SecondColumn, ThirdColumn, FourthColumn) VALUES (@0, @1, @2, @3)", conn);

            insertCommand.Parameters.Add(new SqlParameter("0", "8"));
            insertCommand.Parameters.Add(new SqlParameter("1", "Evening Time"));
            insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
            insertCommand.Parameters.Add(new SqlParameter("3", "6"));

            int rows = insertCommand.ExecuteNonQuery();
            return rows;
        }
    }
}
