using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        [DefaultValue("2000")]
        public DateTime Date { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("BlogElem")]
        public int postId { get; set; }
        [ForeignKey("Comments")]
        [DefaultValue(null)]
        public int commentId { get; set; }
    }
}
