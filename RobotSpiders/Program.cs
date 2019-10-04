using RobotSpiders.Domain;
using RobotSpiders.Exceptions;
using RobotSpiders.Features;
using System;
using System.IO;

namespace RobotSpiders
{
    public class Program
    {
        private static void RunRobotSpider(int wallWidth, int wallHeight, int startX, int startY, string startFacing, string movement)
        {
            try
            {
                var wall = new Wall(wallWidth, wallHeight);
                var position = new Position(startX, startY);
                var spider = new RobotSpider(position, startFacing);
                var robotMover = new RobotMover();

                robotMover.Execute(spider, wall, movement);

                Console.WriteLine($"{spider.GetPosition().X} {spider.GetPosition().Y} {spider.GetFacing()}");
            }
            catch (FallenOffWallException)
            {
                Console.WriteLine("The spider fell off the wall");
            }
            catch (InvalidCharacterException)
            {
                Console.WriteLine("The command should contain only F, L and R characters");
            }
            catch (InvalidDimensionException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void WriteInstructions()
        {
            Console.WriteLine("Usage: Enter the arguments as follows");
            Console.WriteLine("InputFileName   : string");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("WallWidth       : integer");
            Console.WriteLine("WallHeight      : integer");
            Console.WriteLine("SpiderXPosition : integer");
            Console.WriteLine("SpiderYPosition : integer");
            Console.WriteLine("SpiderDirection : Left|Right|Up|Down");
            Console.WriteLine("Movements       : F|L|R repeated");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("SpiderXPosition to Movements can be repeated as many times as desired");
        }
        public static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                RunRobotSpiderFromFile(args[0]);
            }
            else if (args.Length != 2 && args.Length % 4 == 2)
            {
                try
                {
                    RunRobotSpiderFromArguments(args);
                }
                catch (FormatException)
                {
                    WriteInstructions();
                }
            }
            else
            {
                WriteInstructions();
            }
        }

        private static void RunRobotSpiderFromArguments(string[] args)
        {
            int wallWidth = int.Parse(args[0]);
            int wallHeight = int.Parse(args[1]);

            for (var i = 2; i < args.Length; i += 4)
            {
                int spiderX = int.Parse(args[i + 0]);
                int spiderY = int.Parse(args[i + 1]);
                string spiderDirection = args[i + 2];
                string movements = args[i + 3];
                RunRobotSpider(wallWidth, wallHeight, spiderX, spiderY, spiderDirection, movements);
            }
        }

        private static void RunRobotSpiderFromFile(string filePath)
        {
            using (var file = new System.IO.StreamReader(filePath))
            {
                string spiderDirection = null;
                int spiderY = 0;
                int spiderX = 0;
                int wallWidth = 0;
                int wallHeight = 0;

                string line;
                int lineNumber = 0;
                while ((line = file.ReadLine()) != null)
                {
                    var splitLine = line.Split(' ');
                    if (lineNumber == 0)
                    {
                        wallWidth = int.Parse(splitLine[0]);
                        wallHeight = int.Parse(splitLine[1]);
                    }
                    else if (lineNumber % 2 == 1)
                    {
                        spiderX = int.Parse(splitLine[0]);
                        spiderY = int.Parse(splitLine[1]);
                        spiderDirection = splitLine[2];
                    }
                    else if (lineNumber % 2 == 0)
                    {
                        var movement = line.Trim();
                        RunRobotSpider(wallWidth, wallHeight, spiderX, spiderY, spiderDirection, movement);
                    }
                    lineNumber++;
                }
            }
        }
    }
}
