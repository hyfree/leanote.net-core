using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leanoteLibrary.Type
{
    //笔记文件(图片,附件)
    public class NoteFile
    {
        public string FileId;//服务器端ID
        public string LocalFileId;//客户端Id
        public string Type;//images/png, doc, xls, 根据fileName确定
        public string Title;
        public bool HasBody;//传过来的值是否要更新内容, 如果有true, 则必须传文件
        public bool IsAttach; //是否是附件, 不是附件就是图片
    }
}
