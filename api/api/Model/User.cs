using System;

namespace API.Model 
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int LastPosition { get; set; }
        public DateTime LastPositionTime { get; set; }
        public bool Ghostmode { get; set; }
        public string AppToken { get; set; }

        public User(string id, string name, string email, int lastPosition, DateTime lastPositionTime, bool ghostmode, string appToken) {
            Id = id;
            Name = name;
            Email = email;
            LastPosition = lastPosition;
            LastPositionTime = lastPositionTime;
            Ghostmode = ghostmode;
            AppToken = appToken;
        }

        public User() {
            
        }
    }
}