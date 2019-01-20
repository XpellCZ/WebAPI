using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WebAPI.Models
{
    public class TestContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<GroupsRelations> GrRelations { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Texts> Texts { get; set; }
        public DbSet<SeenBy> SeenBys { get; set; }
        public DbSet<FriendsRelations> Friends { get; set; }
        public DbSet<FriendRequest> FriendReq { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            // M:N relace mezi tabulkami Person <-> Course s mezitabulkou PersonCourse
            /*modelBuilder.Entity<Person>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs => {
                    cs.MapLeftKey("PersonId");
                    cs.MapRightKey("CourseId");
                    cs.ToTable("PersonCourse");
                });*/
        }


    }
}