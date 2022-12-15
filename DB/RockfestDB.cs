using Microsoft.EntityFrameworkCore;
using mvc.Entities;
using mvc.Models;
using System.Configuration;

namespace mvc.DB
{
    public class RockfestDB : DbContext
    {
        public DbSet<GuestMessage> GuestMessage { get; set; }
        public DbSet<GuestTicket> GuestTicket { get; set; }
        public DbSet<Group> OptionsGroup { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<BlogElem> BlogElem { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoryPost> CategoryPosts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public RockfestDB(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JFVODSF\\SQLEXPRESS;Initial Catalog=Rockfest;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Group[] groups = new Group[]
            {
            new Group(1,"ContactUs", true),
            new Group(2, "LatestBlog", true),
            new Group(3,"OurSocLinks",true),
            new Group(4, "Link", true),
            new Group(5, "NavBarLink", true),
            };
            modelBuilder.Entity<Group>().HasData(groups);

            Options[] options = new Options[]
            {
                    new Options(1, 1,"08 W 36th St, New York, NY 10001", "/", "fa-map-marker", true),
                    new Options(2, 1, "+1 333 1000 2000", "/", "fa-phone", true),
                    new Options(3, 1, "mailto:contact@example.com", "fa-envelope-o", "", true),

                    new Options(4, 2,"Unreleased Footage of Pearl Jam", "/", "", true),
                    new Options(5, 2,"Kiss Announce New Single", "/","", true),
                    new Options(6, 2,"Guns N' Roses Announce Tour", "/","", true),
                    new Options(7, 2,"Tom Morello New Collaboration", "/","", true),

                    new Options(8, 3, "", "#", "fa-facebook", true),
                    new Options(9, 3, "", "#", "fa-twitter", true),
                    new Options(10, 3, "", "#", "fa-linkedin", true),
                    new Options(11, 3, "", "#", "fa-pinterest", true),
                    new Options(12, 3, "", "#", "fa-rss", true),

                    new Options(13, 4,"Tickets", "/#section-tickets","", true),
                    new Options(14, 4,"Blog", "/Blog","", true),
                    new Options(15, 4,"Contact", "/Contact","", true),
                    new Options(16, 4,"Gallery", "/Gallery","", true),

                    new Options(17, 5, "Main", "/#de-carousel","", true),
                    new Options(18, 5, "Artists", "/#section-artists","", true),
                    new Options(19, 5, "Schedule", "/#section-schedule","", true),
                };
            modelBuilder.Entity<Options>().HasData(options);
        }

    }
}
