namespace ConsoleTestApplication01
{
    using Npgsql;
    using System;
    using System.Collections.Generic;

    internal class TestPostgreSQLConnection
    {
        internal static IList<Car> GetCars()
        {
            string connString = String.Format(Constant.PostgreSQLConnectionString);
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            string sql = "SELECT \"Id\", \"Name\"  FROM public.\"Cars\"";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            IList<Car> list = new List<Car>();

            while (dr.Read())
            {
                list.Add(new Car(int.Parse(dr[0].ToString()), dr[1].ToString()));
            }

            conn.Close();
            return list;
        }
    }
}
