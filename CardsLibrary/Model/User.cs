using CardsLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardsLibrary.Model
{
    public class User : Entity
    {
        public string Alias { get; set; }
        public bool Active { get; set; }
    }
}
