using System;
using System.Collections.Generic;

namespace SWDRepositoryExample.Database
{
    public class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        } 

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; } 
    }
}