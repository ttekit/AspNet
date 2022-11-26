namespace mvc.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public  string GroupName { get; set; }
        public  bool IsPrimary { get; set; }

        public Group(int id, string groupName="", bool isPrimary=false)
        {
            Id = id;
            GroupName = groupName;
            IsPrimary = isPrimary;
        }        
        public Group()
        {

        }
    }
}
