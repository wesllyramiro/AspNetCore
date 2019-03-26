using System;

namespace Web.Api.Core.Domain
{
    public class Tickets
    {
       public string id { get; set; } 
       public string description { get; set; }  
       public string author { get; set; }
       public DateTime creationDate { get; set; }
       public DateTime updated { get; set; }
    }
}