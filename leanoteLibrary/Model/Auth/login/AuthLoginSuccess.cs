using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leanoteLibrary.Model.Auth.login
{
    public class AuthLoginSuccess
    {
        public AuthLoginSuccess()
        {
        }

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
        public static AuthLoginSuccess CreatTest()
        {
            var authLoginSuccess = new AuthLoginSuccess();
            authLoginSuccess.Ok=true;
            authLoginSuccess.Token= "token123";
            authLoginSuccess.UserId= "user123";
            authLoginSuccess.Email= "123@qq.com";
            authLoginSuccess.Username= "hyfree";
            return authLoginSuccess;




        }
    }
}
