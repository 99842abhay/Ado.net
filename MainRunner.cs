using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstertValueProject
{
    class MainRunner
    {
        static void Main(string[] args)
        {
         //   Employeee e = new Employeee();
            Employee2 ep = new Employee2();

            char ch = 'y';
            do
            {
                Console.WriteLine("Enter Your Choise \n @");
                Console.WriteLine("1.Insert\n2.Update\n3.Delete\n4.Display by EmployeeID\n5.Display");

                int n = Convert.ToInt32(Console.ReadLine());
                
                switch (n)
                {
                    case 1:
                        ep.Insert();
                        break;
                    case 2:
                        ep.Update();
                        break;
                    case 3:
                        ep.Delete();
                        break;
                    case 4:
                        ep.SelectAll();
                        break;
                    case 5:
                        ep.dispaly();
                        break;
                    default:
                        Console.WriteLine("Enter the Correct Option ");
                        break;
                }
                Console.WriteLine("do you wish to continue ? press 'y' to continue else press'n'");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch == 'y');
           
            
           
        }
    }
}
