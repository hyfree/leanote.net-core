using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace leanoteLibrary.Type
{
    public class Notebook
    {
        public string NotebookId;
        public string UserId;
        public string ParentNotebookId;
        public int Seq;
        public string Title;
        public bool IsBlog;
        public bool IsDeleted;
        public Rfc3339DateTime CreatedTime;
        public Rfc3339DateTime UpdatedTime;
        public int Usn;//更新序号
    }
}
