using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Snake___Ladder
{
    internal class Player(string name, int playerPosition)
    {
        public string Name { get; set; } = name;

        public int PlayerPosition { get; set; } = playerPosition;
    }
}


