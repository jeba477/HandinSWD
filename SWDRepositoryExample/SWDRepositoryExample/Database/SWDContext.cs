using System.Data.Entity;

namespace SWDRepositoryExample.Database
{
    public class SWDContext : DbContext
    {
        public SWDContext() : base("name=SWDDatabase")
        {
            
        }
         public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasMany(t => t.Posts)
                .WithRequired(t => t.Blog)
                .HasForeignKey(t => t.Blog_Id)
                .WillCascadeOnDelete(true);
        }

    }
}