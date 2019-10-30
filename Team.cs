using System;
using System.Collections.Generic;
using System.Text;

namespace Sport
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}
