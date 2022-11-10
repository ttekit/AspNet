using System;

namespace mvc.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int postId { get; set; }
    }
}
