using CardsLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardsLibrary.Model
{
    public class Move : Entity
    {
        public int? MoveIndex { get; set; }
        public MoveType TypeOfMove { get; set; }
        public string FromPlayerID { get; set; }
        public Player FromPlayer { get; set; }
        public string ToPlayerID { get; set; }
        public Player ToPlayer { get; set; }
        public string TableID { get; set; }
        public Table Table { get; set; }
        public int FromCol { get; set; }
        public int FromRow { get; set; }
        public int ToCol { get; set; }
        public int ToRow { get; set; }
    }

    public enum MoveType
    {
        TableToTable,
        TableToPlayer,
        PlayerToTable,
        PlayerToPlayer
    }
}
