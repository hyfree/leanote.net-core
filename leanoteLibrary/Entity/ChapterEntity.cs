using System;

namespace leanoteLibrary.Entity
{
    public class ChapterEntity
    {
        public string ChapterId{get; set; }
        public string ArticleId{get;set;}
        public string Content{get;set;}
        public string Summary{get; set; }
        public int SerialNumber{get;set;}
        public string Title{get;set;}
        public DateTime CreatTime{get;set;}

    }
}
