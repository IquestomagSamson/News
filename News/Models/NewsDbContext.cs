namespace News.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewsDbContext : DbContext
    {
        public NewsDbContext()
            : base("name=NewsDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<News_comments> News_comments { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .Property(e => e.News_content)
                .IsUnicode(false);
        }
    }
}
