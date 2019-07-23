using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    /// <summary>
    /// RobotSimularor Class that processes the command and instruct the robot as per the command
    /// </summary>
    class RobotSimulator
    {
        public Robot Robot{ get; set; }
        public RobotSimulator(Robot robot)
        {
            this.Robot = robot;
        }
        
        public string Simulate(string command)
        {
            string message = "";
            CommandArguments args=null;
            Command finalCommand = ProcessCommand(command, ref args);
            switch(finalCommand)
            {
                case Command.INVALID:
                    message= "Invalid Command\n";
                    break;
                case Command.PLACE:
                    if (Robot.Place(args.X, args.Y, args.direction))
                        message = "Success";
                    else
                        message = Robot.Message;
                    
                    break;
                case Command.MOVE:
                    if(Robot.Move())
                        message = "Success";
                    else
                        message = Robot.Message;
                    break;
                    
                case Command.LEFT:
                    if(Robot.Left())
                        message = "Success";
                    else
                        message = Robot.Message;
                    break;
                    
                case Command.RIGHT:
                    if(Robot.Right())
                        message = "Success";
                    else
                        message = Robot.Message;
                    break;
                case Command.REPORT:
                    if(Robot.Report())
                        message = "Success";
                    else
                        message = Robot.Message;
                    break;
                default:
                    message = "Invalid Command";
                    break;

            }
            return message;
        }


        public Command ProcessCommand(string command, ref CommandArguments args)
        {
            Command finalCommand;
            
            
            string stringArgs="";
            if (command.IndexOf(' ') > 0)
            {
                string[] commandArray = command.Split(' ');
                stringArgs = command.Substring(command.IndexOf(' ') + 1);
                command = commandArray[0].ToUpper();
                
            }
            else
            {
                command = command.ToUpper();
            }

            if (Enum.TryParse<Command>(command, out finalCommand))
            {
                if (finalCommand == Command.PLACE)
                {
                    if(!TryParseArgs(stringArgs,ref args))
                    {
                        finalCommand = Command.INVALID;
                    }
                }
            }
            else
            {
                finalCommand = Command.INVALID;
            }
            return finalCommand;
           
        }

        public bool TryParseArgs(string stringArgs, ref CommandArguments args)
        {
            int x, y;
            Direction direction;
            string[] argsArray = stringArgs.ToUpper().Split(',');
            
            if (argsArray.Count()==3)
            {
                if (Int32.TryParse(argsArray[0].Trim(), out x) && Int32.TryParse(argsArray[1].Trim(), out y) && Enum.TryParse<Direction>(argsArray[2].Trim(),false, out direction))

                    if(Enum.IsDefined(typeof(Direction), argsArray[2].Trim()))
                    {
                        args = new CommandArguments
                        {
                            X = x,
                            Y = y,
                            direction = direction
                        };
                        return true;
                    }
            }
            
            

            return false;
        }

         
    }
}
