using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            var strudentInputString = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            
            var workerInputString = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            try
            {
                var student = new Student(strudentInputString[0], strudentInputString[1], strudentInputString[2]);
                var worker = new Worker(workerInputString[0], workerInputString[1], decimal.Parse(workerInputString[2]), decimal.Parse(workerInputString[3]));

                Console.WriteLine(student.ToString());
                Console.WriteLine();
                Console.WriteLine(worker.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);              
            }


        }
    }
}
