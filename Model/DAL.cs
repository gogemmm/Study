using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Model
{
    public class DAL
    {
        public SqlConnection connection()
        {
            string scStr = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(scStr);
            sc.Open();
            return sc;
        }
    

        public SqlCommand command(string sql) 
        {
            SqlCommand scom = new SqlCommand(sql,connection());
            return scom;
        }

        public SqlDataAdapter adapter(string sql) 
        {
            SqlCommand scom = this.command(sql);
            SqlDataAdapter adapter = new SqlDataAdapter(scom);
            return adapter;
        }

        public DataSet dataSet(string sql) 
        {
            using (SqlDataAdapter set = this.adapter(sql)) 
            {
                DataSet ds = new DataSet();
                set.Fill(ds);
                return ds;
            }
        }

        //用于delete updata insert,返回受影响的函数
        public int Excute(string sql) 
        {
            return command(sql).ExecuteNonQuery();
        }

        public SqlDataReader read(string sql) 
        {
            return command(sql).ExecuteReader();
        }


    }
}
