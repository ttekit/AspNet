using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Entities
{
    public class CategoryPost
    {
        public int Id { get; set; }
        [ForeignKey("Categories")]
        public string CategoryId { get; set; }
        [ForeignKey("BlogElem")]
        public string PostId { get; set; }

    }
}
