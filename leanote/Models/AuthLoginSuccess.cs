using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leanote.Models
{
    public class AuthLoginSuccess
    {
        public AuthLoginSuccess(bool oK, string token, string userId, string email, string username)
        {
            Ok = oK;
            Token = token;
            UserId = userId;
            Email = email;
            Username = username;
        }

        public bool Ok{ get;set;}
        public string Token{ get;set;}
        public string UserId { get;set;}
        public string Email { get;set;}
        public string Username { get;set;}
       
    }
}
