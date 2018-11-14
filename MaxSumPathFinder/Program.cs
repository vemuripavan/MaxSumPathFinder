using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxSumPathFinder.BusinessLogic;
using MaxSumPathFinder.Common.Contracts;

namespace MaxSumPathFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Enter File Path:");
                //Read input file name
                var FileName = Console.ReadLine();
                var lines = System.IO.File.ReadAllLines(FileName);

                //Convert input collection of integers
                var inputs = lines.Select(c => c.Trim().Split(' ').Select(i => Convert.ToInt16(i)).ToArray()).ToList();

                try
                {
                    IMaxPathFinder maxPathFinder = GetMaxPathFinderInstance();
                    var result = maxPathFinder.FindMaxSumPath(inputs);
                    Console.WriteLine($"Max Sum: {result.MaxSum}");
                    Console.WriteLine($"Max Path: {result.MaxSumPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Console.WriteLine("Would you like to check another file if yes enter 'Y':");
                //if (Console.ReadLine().ToString().ToUpper() != "Y")
                //    break;
            }

        }

        private static IMaxPathFinder GetMaxPathFinderInstance()
        {
            return new PyramidMaxPathFinder();
        }
    }
}
