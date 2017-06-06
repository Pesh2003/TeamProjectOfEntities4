namespace ConsoleTestApplication01
{
    using Npgsql;
    using System;
    using System.Collections.Generic;

    internal class TestPostgreSQLConnection
    {
        internal static IList<User> GetUsers()
        {
            string connString = String.Format(Constant.PostgreSQLConnectionString);
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            string sql = "SELECT Id, Username, Password, Description, UserTypeId  FROM public.Users";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            IList<User> list = new List<User>();

            while (dr.Read())
            {
                list.Add(new User(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), int.Parse(dr[4].ToString())));
            }

            conn.Close();
            return list;
        }
    }
}
