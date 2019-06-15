using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leanoteLibrary.Model.User.info
{
    public class UserInfoSuccess
    {
        public string UserId;
        public string Username;
        public string Email;
        public bool Verified;//验证
        public string Logo;
        public UserInfoSuccess CreatTest()
        {
            UserInfoSuccess userInfo=new UserInfoSuccess();
            userInfo.UserId="user123";
            userInfo.Username="hyfree";
            userInfo.Email="123@qq.com";
            userInfo.Verified=true;
            userInfo.Logo= "http://b-ssl.duitang.com/uploads/item/201609/26/20160926203611_HXQxk.jpeg";
            return userInfo;

        }
    }
}
