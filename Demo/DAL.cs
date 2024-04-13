using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Demo
{
    internal class DAL
    {
        public SqlConnection connection() 
        {
            string scStr = @"Data Source=.\;Initial Catalog=Demo;User Id=sa;Password=000000;";
            SqlConnection sc = new SqlConnection(scStr);
            sc.Open();
            return sc;
        }


        public SqlCommand Command(string sql) 
        {
            SqlCommand scom = new SqlCommand(sql,connection());
            return scom;
        }


        public SqlDataAdapter DataAdapter(string sql) 
        {
            SqlCommand scom = this.Command(sql);
            SqlDataAdapter sqlDataApt = new SqlDataAdapter(scom);
            return sqlDataApt;  
        }

        public DataSet dataset(string sql) 
        {
            using (SqlDataAdapter SAT = this.DataAdapter(sql))
            {
                DataSet ds = new DataSet();
                SAT.Fill(ds);
                return ds;
                
            }

        }



        //用于delete updata insert,返回受影响的函数
        public int Excute(string sql) 
        {
            return Command(sql).ExecuteNonQuery();
        }

        //用于select语句，返回SqldataReader对象,包含select到的数据
        public SqlDataReader read(string sql) 
        {
            return Command(sql).ExecuteReader();
        }

    }
}

