using System;
using System.Threading.Tasks;

namespace CS_Task_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            var task1 = Task.Run(() => { throw new CustomException("This exception is expected!"); });

            try
            {
                task1.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    // Handle the custom exception.
                    if (e is CustomException)
                    {
                        Console.WriteLine($"Exception Occured {e.Message}");
                    }
                    // Rethrow any other exception.
                    else
                    {
                        throw;
                    }
                }
            }
            Console.ReadLine();
        }
    }

    public class CustomException : Exception
    {
        public CustomException(String message) : base(message)
        { }
    }
}
