using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace InstertValueProject
{
    class Employee2
    {
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder scb;
        string query;
        public int EmployeeID { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public float Salary { get; set; }
        public int DepID { get; set; }
        public void dispaly()
        {
            query = "select * from Employee";
            DataTable dt = ds.Tables[0];
            foreach (var r in dt.AsEnumerable())
            {
                Console.WriteLine("{0}\t {1}\t\t {2}\t {3}\t {4}\t", r[0], r[1], r[2], r[3], r[4]);
            }
        }
       
        public Employee2()
        {
            con = new SqlConnection();
            query = "select * from Employee";
            con.ConnectionString = "Server = WKSBAN24KAN0009\\SQLEXPRESS;Database = AbhayDB ; Integrated Security = True ";
            adap = new SqlDataAdapter(query, con);
            ds = new DataSet();
            scb = new SqlCommandBuilder(adap);
            adap.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adap.Fill(ds);
        }
        public void Insert()
        {
            Console.WriteLine("enter EmployeeID:");
            EmployeeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter Country:");
            Country = Console.ReadLine();
            Console.WriteLine("enter Gender:");
            Gender = Console.ReadLine();
            Console.WriteLine("enter Salary:");
            Salary =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("enter DepID:");
            DepID = Convert.ToInt32(Console.ReadLine());
            

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = EmployeeID;
            dr[1] = Country;
            dr[2] = Gender;
            dr[3] = Salary;
            dr[4] = DepID;
         //   dt.Rows.Add(dr);

            adap.Update(ds);
            adap.Fill(ds);     
        }

        public void Update()
        {
            Console.WriteLine("enter EmployeeID:");
            EmployeeID = Convert.ToInt32(Console.ReadLine());

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows.Find(EmployeeID);

            Console.WriteLine("enter Country:");
            Country = Console.ReadLine();
            Console.WriteLine("enter Gender:");
            Gender = Console.ReadLine();
            Console.WriteLine("enter salary:");
            Salary = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("enter DepID");
            DepID =Convert.ToInt32(Console.ReadLine());

            dr.BeginEdit();
            dr[1] = Country;
            dr[2] = Gender;
            dr[3] = Salary;
            dr[4] = DepID;
           // dt.Rows.Add(dr);
              dr.EndEdit();


            adap.Update(ds);
            adap.Fill(ds);
        }
        public void Delete()
        {
            Console.WriteLine("enter EmployeeID:");
            EmployeeID = Convert.ToInt32(Console.ReadLine());

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows.Find(EmployeeID);

            dt.Rows.Remove(dr);
            adap.Update(ds);
            adap.Fill(ds);
        }
        public void SelectAll()
        {
            DataTable dt = ds.Tables[0];
            foreach (DataRow r in dt.AsEnumerable())
            {
                Console.WriteLine("{0},{1},{2},{3},{4}", r[0], r[1], r[2], r[3], r[4]);
            }

        }
        public void SelectById()
        {
            Console.WriteLine("Enter EmployeeID");
            EmployeeID = Convert.ToInt32(Console.ReadLine());

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows.Find(EmployeeID);

            Console.WriteLine("{0},{1},{2},{3},{4}", dr[0], dr[1], dr[2], dr[3], dr[4]);
        }


        /*
         public void Insert()
         {
             string query = "insert into Employee values(@EmployeeID, @Country, @Gender, @Salary, @DepID)";
             // string query = "insert into Employee3 values(@Id,@Name,@Department,@Designation,@Salary)";
             //cmd = new SqlCommand();
             //cmd.CommandType = System.Data.CommandType.StoredProcedure;
             //cmd.CommandText = "InsertEmployee";
             //cmd.Connection = con;
             //cmd = new SqlCommand(query, con);

             Console.WriteLine("Enter the EmployeeID");
             EmployeeID = Convert.ToInt32(Console.ReadLine());
             cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

             Console.WriteLine("Enter the Country");
             Country = Console.ReadLine();
             cmd.Parameters.AddWithValue("@Country", Country);

             Console.WriteLine("Enter the Gender");
             Gender = Console.ReadLine();
             cmd.Parameters.AddWithValue("@Gender", Gender);

             Console.WriteLine("Enter the Salary");
             Salary = Convert.ToInt32(Console.ReadLine());
             cmd.Parameters.AddWithValue("@Salary", Salary);

             Console.WriteLine("Enter the DepID");
             DepID = Convert.ToInt32(Console.ReadLine());
             cmd.Parameters.AddWithValue("@DepID", DepID);

             int i = cmd.ExecuteNonQuery();
             Console.WriteLine("One row inserted ");
         }

         public void Update()
         {
             string query = "update Employee set Country =@Country, Gender = @Gender, Salary=@Salary, DepID=@DepID where EmployeeID =@EmployeeID";
             //cmd = new SqlCommand();
             //cmd.CommandType = System.Data.CommandType.StoredProcedure;
             //cmd.CommandText = "UpdateEmployee";
             //cmd.Connection = con;
             //cmd = new SqlCommand(query, con);

             Console.WriteLine("Enter the EmployeeID");
             EmployeeID = Convert.ToInt32(Console.ReadLine());
             cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

             Console.WriteLine("Enter the Country");
             Country = Console.ReadLine();
             cmd.Parameters.AddWithValue("@Country", Country);

             Console.WriteLine("Enter the Gender");
             Gender = Console.ReadLine();
             cmd.Parameters.AddWithValue("@Gender", Gender);

             Console.WriteLine("Enter the Salary");
             Salary = Convert.ToInt32(Console.ReadLine());
             cmd.Parameters.AddWithValue("@Salary", Salary);

             Console.WriteLine("Enter the DepID");
             DepID = Convert.ToInt32(Console.ReadLine());
             cmd.Parameters.AddWithValue("@DepID", DepID);

             int i = cmd.ExecuteNonQuery();
             Console.WriteLine("One row updated");
         }
         public void Delete()
         {
             string query = "Delete from Employee where EmployeeID=@EmployeeID";
             //cmd = new SqlCommand();
             //cmd.CommandType = System.Data.CommandType.StoredProcedure;
             //cmd.CommandText = "UpdateEmployee";
             //cmd.Connection = con;
             cmd = new SqlCommand(query, con);

             Console.WriteLine("Enter the EmployeeID");
             EmployeeID = Convert.ToInt32(Console.ReadLine());
             cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

             int i = cmd.ExecuteNonQuery();
             Console.WriteLine("One row deleted");
         }
         public void SelectAll()
         {
             string query = "select * from Employee";
             //cmd = new SqlCommand();
             //cmd.CommandType = System.Data.CommandType.StoredProcedure;
             //cmd.CommandText = "SelectEmployee";
             //cmd.Connection = con;
             cmd = new SqlCommand(query, con);

             sdr = cmd.ExecuteReader();
             Console.WriteLine("\nEmpID\t Country\t Gender\t\tSalary\tDeptID");
             Console.WriteLine("=====================================================================");
             while (sdr.Read())
             {
                 Console.WriteLine("{0}\t {1}\t\t {2}\t {3}\t {4}\t", sdr[0], sdr[1], sdr[2], sdr[3], sdr[4]);
             }
             //int i = cmd.ExecuteNonQuery();
             Console.WriteLine("Display All the record");
         }
         public void SelectById()
         {
             //string query = "select * from Employee where EmployeeID =@EmployeeID";
             //cmd = new SqlCommand();
             //cmd.CommandType = System.Data.CommandType.StoredProcedure;
             //cmd.CommandText = "UpdateEmployee";
             //cmd.Connection = con;
             cmd = new SqlCommand(query, con);

             Console.WriteLine("Enter the EmployeeID");
             EmployeeID = Convert.ToInt32(Console.ReadLine());
             cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
             sdr = cmd.ExecuteReader();
             Console.WriteLine("\nThe details of Employee are : ");
             Console.WriteLine("\nEmpID\t Country\t Gender\t\tSalary\tDeptID");
             Console.WriteLine("=====================================================================");
             sdr.Read();
             Console.WriteLine("{0}\t {1}\t\t {2}\t {3}\t {4}", sdr[0], sdr[1], sdr[2], sdr[3], sdr[4]);
             // int i = cmd.ExecuteNonQuery();
             Console.WriteLine("id Record Displayed :");
         }
         */
    }
}
