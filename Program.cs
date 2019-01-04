using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseDemo
{
    class Program
    {

        //static void Main(string[] args)
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = "Server = WKSBAN24KAN0009\\SQLEXPRESS;Database = AbhayDB ; Integrated Security = True ";
        //   // con.ConnectionString = "Data Source = WKSBAN24KAN0009\\SQLEXPRESS;Initial Cataloge = AbhayDB ; Integrated Security = True ";
        //    con.Open();

        //    string query = "select * from Employee";

        //    SqlCommand cmd = new SqlCommand(query, con);

        //    SqlDataReader sdr = cmd.ExecuteReader();

        //    Console.WriteLine("id\tcountry\t\tgender\tsalary\tdepId");
        //    Console.WriteLine("=============================================================");

        //    while(sdr.Read())
        //    {
        //        Console.WriteLine("{0}\t {1}\t\t {2}\t {3}\t {4}",sdr[0], sdr[1], sdr[2], sdr[3], sdr[4]);
        //    }
        //    Console.ReadLine();
        //}
        static void Main(string[] args)
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = "Server = WKSBAN24KAN0009\\SQLEXPRESS;Database = AbhayDB ; Integrated Security = True ";
                // con.ConnectionString = "Data Source = WKSBAN24KAN0009\\SQLEXPRESS;Initial Cataloge = AbhayDB ; Integrated Security = True ";
                con.Open();

                string query = "select * from Employee";

                //  using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter adap = new SqlDataAdapter(query, con))
                {
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    try
                    {

                        Console.WriteLine("Enter the Id ---");
                        int id = Convert.ToInt32(Console.ReadLine());

                        DataView dv = new DataView();
                        dv.Table = ds.Tables[0];
                        //   cmd.Parameters.Add(new SqlParameter("@EmployeeID", id));
                        //  SqlDataReader sdr = cmd.ExecuteReader();
                        // sdr.Read();
                        dv.RowFilter = "EmployeeID = " + id;
                        Console.WriteLine("id\tcountry\t\tgender\tsalary\tdepId");
                        Console.WriteLine("=============================================================");

                        Console.WriteLine("{0}\t {1}\t{2}\t {3}\t {4}", dv[0][0], dv[0][1], dv[0][2], dv[0][3], dv[0][4]);
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                
                   // adap.Fill(ds);

                     DataTable dt = ds.Tables["Employee"];
                }

                //1st Way

                // cmd.Parameters.AddWithValue("@EmployeeID", id);
                //2nd way
                //cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                //cmd.Parameters["@EmployeeID"].Value = id;

                //3rd way 

                // SqlDataReader sdr = cmd.ExecuteReader();

                //Console.WriteLine("id\tcountry\t\tgender\tsalary\tdepId");
                //Console.WriteLine("=============================================================");
                // SqlDataAdapter adap = new SqlDataAdapter(query, con);

                //DataSet ds = new DataSet();
                //foreach (DataRow r in dt.AsEnumerable())
                //{
                //    Console.WriteLine("{0}\t {1}\t\t {2}\t {3}\t {4}", r[0], r[1], r[2], r[3], r[4]);
                //}
                Console.ReadLine();
            }
        }
    }
}
