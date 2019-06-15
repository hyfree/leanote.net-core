
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leanoteLibrary.Type
{
    public class Note
    {
        public string NoteId;
        public string NotebookId;
        public string UserId;
        public string Title;
        public List<string> Tags;
        public string Content;
        public bool IsMarkdown;
        public bool IsBlog;
        public bool IsTrash;
        public List<NoteFile> Files;
        public Rfc3339DateTime CreatedTime;
        public Rfc3339DateTime UpdatedTime;
        public Rfc3339DateTime PublicTime;
        public int Usn;//更新序号


    }
}
