namespace mvc.Entities
{
    public class BlogPagination
    {
        public int Page { get; set; }
        
        public int CurrentCount { get; set; }

        public int CategoryId { get; set; }

        public BlogPagination(int page, int currentCount, int categoryId)
        {
            Page = page;
            CurrentCount = currentCount;
            CategoryId = categoryId;
        }
        public BlogPagination()
        {

        }
    }
}
