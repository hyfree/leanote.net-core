﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leanoteLibrary.Model.Auth.login
{
    public class AuthLoginError
    {
        public AuthLoginError(bool oK, string msg)
        {
            OK = oK;
            Msg = msg;
        }

        public bool OK { get; set; }
        public string Msg { get; set; }
      
    }
}
