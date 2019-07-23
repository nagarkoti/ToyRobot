using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    /// <summary>
    /// Class with properties for PLACE command with 3 arguments
    /// </summary>
    class CommandArguments
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction direction{ get; set; }
    }
}
