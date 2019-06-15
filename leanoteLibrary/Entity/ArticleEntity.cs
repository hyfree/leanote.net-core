using System;

namespace leanoteLibrary.Entity
{
    public class ArticleEntity
    {
       public string ArticleId{get; set; }
       public string Title{get; set; }
       public string CreatUser{get; set; }
       public DateTime CreatTime{get; set; }
       public string Author{get; set; }
       public int Score{get; set; }
       public string ArticleType{get; set; }
       public string Sources{get; set; }
       public string Status{get; set; }
       public string Summary{get; set; }
       public string Description{get; set; }
       public string SEOTitle{get; set; }
       public string SEOKeyWord{get; set; }
       public string SEODescription{get; set; }

       public bool AllowComments{get; set; }
       public bool Topping{get; set; }
       public bool Recommend{get; set; }
       public bool Hot{get; set; }
       public bool TurnMap{get; set; }
       public string RecType{get; set; }

    }
}
