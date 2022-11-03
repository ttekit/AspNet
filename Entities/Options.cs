namespace mvc.Entities
{
    public class Options
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string Value { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public Options(int id, string group = "", string value = "", string href = "/", string icon = "/")
        {
            Id = id;
            Href = href;
            Icon = icon;
            Group = group;
            Value = value;
        }

    }
}
