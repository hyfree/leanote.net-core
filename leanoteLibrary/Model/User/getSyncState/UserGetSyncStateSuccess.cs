using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leanoteLibrary.Model.User.getSyncState
{
    public class UserGetSyncStateSuccess
    {
        public string LastSyncTime;//上次更新时间（暂时无用）1560258404
        public string LastSyncUsn;//2517
        public static UserGetSyncStateSuccess CreatTest()
        {
            UserGetSyncStateSuccess userGetSyncStateSuccess=new UserGetSyncStateSuccess();
            userGetSyncStateSuccess.LastSyncTime= "1560262543";
            userGetSyncStateSuccess.LastSyncUsn= "2517";
            return userGetSyncStateSuccess;
        }

    }
    
}
