using CardsLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardsLibrary.Model
{
    public class Game: Entity
    {
        public string Name { get; set; }
        public List<Table> Tables { get; set; }
    }
}
