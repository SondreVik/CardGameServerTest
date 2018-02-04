using CardsLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardsLibrary.Model
{
    public class LoggedInUser : Entity
    {
        public DateTime LoggedIn { get; set; }
        public User User { get; set; }
        public string UserID { get; set; }
        public string Token { get; set; }
    }
}
