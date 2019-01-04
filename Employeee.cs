using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InstertValueProject
{
    class Employeee
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;


        public int EmployeeID { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int DepID { get; set; }

        public Employeee()
        {
            con = new SqlConnection();
            con.ConnectionString = "Server = WKSBAN24KAN0009\\SQLEXPRESS;Database = AbhayDB ; Integrated Security = True ";
            con.Open();
        }
        public void Insert()
        {
            string query = "insert into Employee values(@EmployeeID, @Country, @Gender, @Salary, @DepID)";
            // string query = "insert into Employee3 values(@Id,@Name,@Department,@Designation,@Salary)";
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmployee";
            cmd.Connection = con;
            cmd = new SqlCommand(query, con);

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
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "UpdateEmployee";
            cmd.Connection = con;
            cmd = new SqlCommand(query, con);

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
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "UpdateEmployee";
            cmd.Connection = con;
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
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectEmployee";
            cmd.Connection = con;
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
            string query = "select * from Employee where EmployeeID =@EmployeeID";
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "UpdateEmployee";
            cmd.Connection = con;
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

    }
}


