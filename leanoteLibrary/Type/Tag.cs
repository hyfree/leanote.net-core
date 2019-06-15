using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leanoteLibrary.Type
{
    public class TagObj
    {
        public string TagId;
        public string UserId;
        public string Tag;
        public Rfc3339DateTime CreatedTime;
        public Rfc3339DateTime UpdatedTime;
        public bool IsDeleted;
        public int Usn;//更新序号
    }
}
