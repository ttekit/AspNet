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
        public DbSet<Options> Options { get; set; }
        public DbSet<BlogElem> BlogElem { get; set; }

        public RockfestDB(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JFVODSF\\SQLEXPRESS;Initial Catalog=Rockfest;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Options[] options = new Options[]
            {
                    new Options(1, "contactUs","08 W 36th St, New York, NY 10001", "/", "fa-map-marker"),
                    new Options(2, "contactUs", "+1 333 1000 2000", "/", "fa-phone"),
                    new Options(3, "contactUs", "mailto:contact@example.com", "fa-envelope-o"),

                    new Options(4, "LatestBlog","Unreleased Footage of Pearl Jam", "/"),
                    new Options(5, "LatestBlog","Kiss Announce New Single", "/"),
                    new Options(6, "LatestBlog","Guns N' Roses Announce Tour", "/"),
                    new Options(7, "LatestBlog","Tom Morello New Collaboration", "/"),

                    new Options(8, "OurSocLinks", "", "#", "fa-facebook"),
                    new Options(9, "OurSocLinks", "", "#", "fa-twitter"),
                    new Options(10, "OurSocLinks", "", "#", "fa-linkedin"),
                    new Options(11, "OurSocLinks", "", "#", "fa-pinterest"),
                    new Options(12, "OurSocLinks", "", "#", "fa-rss"),

                    new Options(13, "link","Tickets", "/#section-tickets"),
                    new Options(14, "link","Blog", "/Blog"),
                    new Options(15, "link","Contact", "/Contact"),
                    new Options(16, "link","Gallery", "/Gallery"),

                    new Options(17, "navBarLink", "Main", "/#de-carousel"),
                    new Options(18, "navBarLink", "Artists", "/#section-artists"),
                    new Options(19, "navBarLink", "Schedule", "/#section-schedule"),
                };

            BlogElem[] blogElems = new BlogElem[] {
                new BlogElem() {
                    Id = 1,
                    Title = "Hematochezia nonpurchase alilonghi funt Istiophorus victualer incunabula",
                    ImgSrc = "images/blog/1.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                },
                new BlogElem() {
                    Id = 2,
                    Title = "Corticipetally unentrance Ponerinae anthocyan multiserial parsonship penumbrous",
                    ImgSrc = "images/blog/2.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                },
                new BlogElem() {
                    Id = 3,
                    Title = "Latching aphagia prostatelcosis gadolinium hemikaryon aftergrief ventricumbent Swab",
                    ImgSrc = "images/blog/3.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                },
                new BlogElem(){
                    Id = 4,
                    Title = "Thermodynamicist aeolistic lipsanotheca nearaway Tamworth pycnid subtower",
                    ImgSrc = "images/blog/4.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                },
                new BlogElem(){
                    Id = 5,
                    Title = "Unpresumptuously carnelian trochiscus echoic enmask myodynamiometer",
                    ImgSrc = "images/blog/5.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                },
                new BlogElem(){
                    Id = 6,
                    Title = "Statesmanese pseudhemal steatite Wendish boxhaul equiprobability xylonic",
                    ImgSrc = "images/blog/6.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                }
        };

            modelBuilder.Entity<Options>().HasData(options);
            modelBuilder.Entity<BlogElem>().HasData(blogElems);
        }

    }
}
