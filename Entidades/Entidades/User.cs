﻿using System;

namespace Entidades.Entidades
{
    public class User
    {
        public string username { get; set; }

        public string password { get; set; }
        
        public string email { get; set; }

        public DateTime date { get; set; }

        public string token { get; set; }
    }
}
