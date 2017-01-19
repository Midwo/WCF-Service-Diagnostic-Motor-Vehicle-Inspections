using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public class Connection
    {

        private string sqlconncetionstring = WcfService1.Properties.Settings.Default.conwcfbase;

        public DataSet sqldata(string cmd)
        {
            using (SqlConnection connection = new SqlConnection(sqlconncetionstring))
            {
                connection.Open();

                SqlDataAdapter adp = new SqlDataAdapter(cmd, connection);

                DataSet ds = new DataSet();
                try
                {
                    adp.Fill(ds);
                }
                catch
                {
                    return ds;
                }
                return ds;
            }
        }

       public  void sqlcommand(string cmd)
        {
            using (SqlConnection connection = new SqlConnection(sqlconncetionstring))
            {
                SqlCommand command = new SqlCommand(cmd, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}