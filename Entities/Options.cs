using Microsoft.EntityFrameworkCore;
using mvc.DB;
using mvc.Models;

namespace mvc.Entities
{
    public class Options
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Value { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public bool IsPrimary { get; set; }
        /*
         GroupId: "5"
         Href: "asdf"
         Icon: "asdfasdfgfd"
         Id: "38"
         Value: "asdf"
         */

        public Options(int id, int group, string value = "", string href = "/", string icon = "/", bool isPrimary = false)
        {
            Id = id;
            Href = href;
            Icon = icon;
            GroupId = group;
            Value = value;
            IsPrimary = isPrimary;
        }
        public Options(int id, string group, string value = "", string href = "/", string icon = "/", bool isPrimary = false)
        {
            Id = id;
            Href = href;
            Icon = icon;
            GroupId = int.Parse(group);
            Value = value;
            IsPrimary = isPrimary;
        }
        public Options()
        {
            Href = "/";
            Icon = "";
            Value = "";
            IsPrimary = false;
        }
    }
}
