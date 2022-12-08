using System;

namespace mvc.Entities
{
    public class BlogElem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgSrc { get; set; }
        public string ImgAlt { get; set; } 
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public BlogElem(int id, string title, string imgSrc, string imgAlt, string content, DateTime date)
        {
            Id = id;
            Title = title;
            ImgSrc = imgSrc;
            ImgAlt = imgAlt;
            Content = content;
            Date = date;
        }
        public BlogElem()
        {

        }
    }
}
