using RobotCleaner.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get run parameters from Console
            var numberOfCommands = Convert.ToInt32(Console.ReadLine());
            var startingPostion = Console.ReadLine();
            var startingX = Convert.ToInt32(startingPostion.Split(' ')[0]);
            var startingY = Convert.ToInt32(startingPostion.Split(' ')[1]);
            var directions = new List<KeyValuePair<char, int>>();


            for (var i = 0; i < numberOfCommands; i++)
            {
                var direction_string = Console.ReadLine();
                var direction = Convert.ToChar(direction_string.Split(' ')[0]);
                var steps = Convert.ToInt32(direction_string.Split(' ')[1]);
                directions.Add(new KeyValuePair<char, int>(direction, steps));
            }

            //Call Processor method
            var cleanResult = RobotProcessor.Clean(startingX, startingY, directions);

            //Write Result
            Console.WriteLine($"=> Cleaned: {cleanResult}");
            Console.ReadKey();
        }
    }
}
