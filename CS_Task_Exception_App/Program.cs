using System;
using System.Threading.Tasks;

namespace CS_Task_Exception_App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter x and y");
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());

                Task<int> t = Task<int>.Factory.StartNew(() => { return Divide(x, y); });


                Console.WriteLine(t.Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }

        static int Divide(int x,int y)
        {
            if (y == 0)
                throw new DivideByZeroException("Denominator cannot be zero {y}");

            return x / y;

        }
    }
}
