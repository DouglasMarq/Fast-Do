using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fast_Do.Models
{
    [Table("Login")]
    public class Login
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }
}
