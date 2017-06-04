namespace ConsoleTestApplication01
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    internal class TestSQLServerConnection
    {
        internal static IList<Service> GetServices()
        {
            string connstring = String.Format(Constant.SQLServerConnectionString);
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string sql = "SELECT * FROM [TestExample].[dbo].[Services]";
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dr = command.ExecuteReader();
            IList<Service> list = new List<Service>();

            while (dr.Read())
            {
                list.Add(new Service(int.Parse(dr[0].ToString()), dr[1].ToString()));
            }

            conn.Close();
            return list;
        }
    }
}
