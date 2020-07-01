using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CS_Return_Value_From_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            // Return a value type with a lambda expression
            Task<int> task1 = Task<int>.Factory.StartNew(() => 1);
            int i = task1.Result;
            Console.WriteLine(i);

            // Return a named reference type with a multi-line statement lambda.
            Task<Test> task2 = Task<Test>.Factory.StartNew(() =>
            {
                string s = ".NET";
                double d = 4.0;
                return new Test { Name = s, Number = d };
            });
            Test test = task2.Result;

            Console.WriteLine(JsonSerializer.Serialize(test));

            // Return an array produced by a PLINQ query
            Task<string[]> task3 = Task<string[]>.Factory.StartNew(() =>
            {
                string path = @"E:\whirpool\SpotApps\CS_Apps\CS_Tuples";
                string[] files = System.IO.Directory.GetFiles(path);

                var result = (from file in files.AsParallel()
                              let info = new System.IO.FileInfo(file)
                              where info.Extension == ".cs"
                              select file).ToArray();

                return result;
            });

            foreach (var name in task3.Result)
                Console.WriteLine(name);

            Console.ReadLine();
        }
    }

    public class Test
    {
        public string Name { get; set; }
        public double Number { get; set; }
    }
}
