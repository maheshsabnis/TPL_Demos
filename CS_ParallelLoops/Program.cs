
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace CS_ParallelLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ = new EmployeeList();
            Console.WriteLine($"Non-Parallel Processing Starts {DateTime.Now}");
            var swNonParallel = Stopwatch.StartNew();
            for (int i = 0; i < _.Count; i++)
            {
                ProcessTax.CalculateTax(_[i]);
                Console.WriteLine($"Sequential Employee Record after tax {JsonSerializer.Serialize(_[i])}");
            }
            Console.WriteLine($"Non-Parallel Process completed at {DateTime.Now}" +
                $"Total Time {swNonParallel.Elapsed.TotalSeconds}");


            Console.WriteLine($"Parallel Processing Starts {DateTime.Now}");

            var swParallel = Stopwatch.StartNew();
            //Parallel.For(0, _.Count, i =>
            //{
            //    ProcessTax.CalculateTax(_[i]);
            //    Console.WriteLine($"Parallel Employee Record after tax {JsonSerializer.Serialize(_[i])}");
            //});
            Parallel.ForEach<Employee>(_, emp =>
            {
                ProcessTax.CalculateTax(emp);
                Console.WriteLine($"Parallel Employee Record after tax {JsonSerializer.Serialize(emp)}");
            });
            Console.WriteLine($"Parallel Process completed at {DateTime.Now}" +
                $"Total Time {swParallel.Elapsed.TotalSeconds}");


            Console.ReadLine();
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public decimal Tax { get; set; }
    }

    public static class ProcessTax
    {
        public static Employee CalculateTax(Employee emp)
        {
            System.Threading.Thread.Sleep(100);
            emp.Tax = emp.Salary * Convert.ToDecimal(0.4);
            return emp;
        }
    }

    public class EmployeeList : List<Employee>
    {
        public EmployeeList()
        {
            Add(new Employee() { EmpNo = 1, EmpName = "A", Salary = 21000 });
            Add(new Employee() { EmpNo = 2, EmpName = "B", Salary = 22000 });
            Add(new Employee() { EmpNo = 3, EmpName = "C", Salary = 23000 });
            Add(new Employee() { EmpNo = 4, EmpName = "D", Salary = 24000 });
            Add(new Employee() { EmpNo = 5, EmpName = "E", Salary = 25000 });
            Add(new Employee() { EmpNo = 6, EmpName = "F", Salary = 26000 });
            Add(new Employee() { EmpNo = 7, EmpName = "G", Salary = 27000 });
            Add(new Employee() { EmpNo = 8, EmpName = "H", Salary = 28000 });
            Add(new Employee() { EmpNo = 9, EmpName = "I", Salary = 29000 });
            Add(new Employee() { EmpNo = 10, EmpName = "J", Salary = 30000 });
            Add(new Employee() { EmpNo = 11, EmpName = "K", Salary = 31000 });
            Add(new Employee() { EmpNo = 12, EmpName = "L", Salary = 32000 });
            Add(new Employee() { EmpNo = 13, EmpName = "M", Salary = 33000 });
            Add(new Employee() { EmpNo = 14, EmpName = "N", Salary = 34000 });
            Add(new Employee() { EmpNo = 15, EmpName = "O", Salary = 35000 });
            Add(new Employee() { EmpNo = 16, EmpName = "P", Salary = 36000 });
            Add(new Employee() { EmpNo = 17, EmpName = "Q", Salary = 37000 });
            Add(new Employee() { EmpNo = 18, EmpName = "R", Salary = 38000 });
            Add(new Employee() { EmpNo = 19, EmpName = "S", Salary = 39000 });
            Add(new Employee() { EmpNo = 20, EmpName = "T", Salary = 40000 });
            Add(new Employee() { EmpNo = 21, EmpName = "U", Salary = 41000 });
            Add(new Employee() { EmpNo = 22, EmpName = "V", Salary = 42000 });
            Add(new Employee() { EmpNo = 23, EmpName = "W", Salary = 43000 });
            Add(new Employee() { EmpNo = 24, EmpName = "X", Salary = 44000 });
            Add(new Employee() { EmpNo = 25, EmpName = "Y", Salary = 45000 });
            Add(new Employee() { EmpNo = 26, EmpName = "Z", Salary = 46000 });

        }
    }
}
