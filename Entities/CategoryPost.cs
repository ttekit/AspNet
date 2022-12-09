using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Entities
{
    public class CategoryPost
    {
        public int Id { get; set; }
        [ForeignKey("Categories")]
        public string CategoryId { get; set; }
        [ForeignKey("BlogElem")]
        public int PostId { get; set; }

        public CategoryPost()
        {

        }
        public CategoryPost(int postId, int catId)
        {
            CategoryId = catId.ToString();
            PostId = postId;
        }
    }
}
