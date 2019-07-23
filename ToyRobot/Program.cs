using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            int tableSize = 5;
            RobotSimulator robotSimulator = new RobotSimulator(new Robot(tableSize));
            Console.WriteLine("*************ROBOT SIMULATOR***********\nTABLE SIZE 5x5\nValid Commands:\n " +
                                        "\n PLACE X,Y,DIRECTION [Ex: PLACE 0,0,EAST]" +
                                        "\n MOVE" +
                                        "\n LEFT" +
                                        "\n RIGHT" +
                                        "\n REPORT");
            while (true)
            {
                Console.WriteLine("\nPlease enter a command:");
                String command = Console.ReadLine();
                Console.WriteLine(robotSimulator.Simulate(command.Trim()));            
            }
           
        }

        
    }

}
