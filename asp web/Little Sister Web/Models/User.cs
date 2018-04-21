using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Little_Sister_Web.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int LastPosition { get; set; }
        public string AppToken { get; set; }
        public DateTime LastPositionTime { get; set; }
        public bool Ghostmode { get; set; }
        public string Name { get; set; }
        public User(string i, string m, int l, string a, DateTime t, bool g, string n)
        {
            Id = i;
            Email = m;
            LastPosition = l;
            AppToken = a;
            LastPositionTime = t;
            Ghostmode = g;
            Name = n;
        }
    }
}