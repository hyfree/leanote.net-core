using System;

namespace leanoteLibrary.Entity
{
    public class PayEntity
    {
       public  string Id { get; set; }
       public  string UserId { get; set; }
       public  string Type { get; set; }
       public  string Chapter { get; set; }
        public  DateTime PayTime { get; set;}
        public  int Money { get; set; }

    }
}
