using System;

namespace SWDRepositoryExample.Database
{
    public class Post
    {
        public Post()
        {
            
        } 

        public int Id { get; set; }

        public DateTime Time { get; set; }
        public string Content { get; set; }

        public int Blog_Id { get; set; }
        public virtual Blog Blog { get; set; }
    }
}