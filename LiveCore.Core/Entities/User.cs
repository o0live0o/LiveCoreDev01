using System;

namespace LiveCore.Core.Entities
{
    public class User:Entity    
    {
        public string UserNameP{get;set;}
        public string Password{get;set;}
        public DateTime LastModified{get;set;}
    }
}