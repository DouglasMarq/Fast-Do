using System;

namespace Entidades.Entidades
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }
        
        public string Email { get; set; }

        public DateTime Date { get; set; }

        public string Token { get; set; }
    }
}
