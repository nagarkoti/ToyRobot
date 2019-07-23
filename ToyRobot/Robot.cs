using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public enum Command
    {
        INVALID,
        PLACE,
        MOVE,
        LEFT,
        RIGHT,
        REPORT
    }
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    /// <summary>
    /// Robot Class to handle all the simulation commands
    /// </summary>
    public class Robot
    {
        public int? X { get; set; }
        public int? Y { get; set; }
        public Direction? Direction { get; set; }
        public int TableSize { get; set; }
        public String Message { get; set; }

        public const string NotPlacedYet = "The robot hasn't been placed on the table yet. Please use PLACE command as your first instruction";
        public const string OutOfBoundary = "Cannot be placed/moved outside boundary";
        public const string InvalidCommand = "Invalid Command. Use commands" +
                                        "\n Valid Commands:" +
                                        "\n PLACE X,Y,DIRECTION" +
                                        "\n MOVE" +
                                        "\n LEFT" +
                                        "\n RIGHT" +
                                        "\n REPORT";

        public Robot(int tableSize)
        {
            TableSize = tableSize;
        }
        public bool Place(int x, int y, Direction direction)
        {
            if (x < 0 || x > 4 || y < 0 || y > 4)
            {
                this.Message = OutOfBoundary;
                return false;
            }
            else
            {
                this.X = x;
                this.Y = y;
                this.Direction = direction;
                return true;
            }
        }
        public bool Move()
        {
            if (this.X.HasValue)
            {
                switch (this.Direction)
                {
                    case ToyRobot.Direction.NORTH:
                        if (++this.Y < 5)
                        {
                            return true;
                        }
                        else
                        {
                            this.Y--;
                            return false;
                        }

                    case ToyRobot.Direction.SOUTH:


                        if (--this.Y > -1)
                        {
                            return true;
                        }
                        else
                        {
                            this.Y++;
                            return false;
                        }
                    case ToyRobot.Direction.WEST:
                        if (++this.X < 5)
                        {
                            return true;
                        }
                        else
                        {
                            this.X--;
                            return false;
                        }
                    case ToyRobot.Direction.EAST:
                        if (++this.X > -1)
                        {
                            return true;
                        }
                        else
                        {
                            this.X++;
                            return false;
                        }
                    default:
                        return false;
                }
            }
            else
            {
                this.Message = NotPlacedYet;
                return false;
            }
        }
        public bool Left()
        {
            if (this.X.HasValue)
            {
                switch (this.Direction)
                {
                    case ToyRobot.Direction.EAST:
                        this.Direction = ToyRobot.Direction.NORTH;
                        return true;
                    case ToyRobot.Direction.NORTH:
                        this.Direction = ToyRobot.Direction.WEST;
                        return true;
                    case ToyRobot.Direction.WEST:
                        this.Direction = ToyRobot.Direction.SOUTH;
                        return true;
                    case ToyRobot.Direction.SOUTH:
                        this.Direction = ToyRobot.Direction.EAST;
                        return true;
                    default:
                        return false;
                }

            }
            else
            {
                this.Message = NotPlacedYet;
                return false;
            }

        }
        public bool Right()
        {
            if (this.X.HasValue)
            {
                switch (this.Direction)
                {
                    case ToyRobot.Direction.EAST:
                        this.Direction = ToyRobot.Direction.SOUTH;
                        return true;
                    case ToyRobot.Direction.SOUTH:
                        this.Direction = ToyRobot.Direction.WEST;
                        return true;
                    case ToyRobot.Direction.WEST:
                        this.Direction = ToyRobot.Direction.NORTH;
                        return true;
                    case ToyRobot.Direction.NORTH:
                        this.Direction = ToyRobot.Direction.EAST;
                        return true;
                    default:
                        return false;
                }

            }
            else
            {
                this.Message = NotPlacedYet;
                return false;
            }
        }
        public bool Report()
        {
            if (this.X.HasValue)
            {
                Console.WriteLine("Output: {0},{1},{2}", this.X, this.Y, this.Direction);
                return true;
            }
            else
            {
                this.Message = NotPlacedYet;
                return false;
            }
            
        }

    }
}
