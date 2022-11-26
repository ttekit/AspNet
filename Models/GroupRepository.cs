using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using mvc.DB;
using mvc.Entities;
using System.Linq;

namespace mvc.Models
{
    public class GroupRepository
    {
        private static readonly RockfestDB _rockfestDB = new DB.RockfestDB(new DbContextOptions<RockfestDB>());

        public static Group GetGroupById(int id)
        {
            return _rockfestDB.OptionsGroup.First(option => option.Id == id);
        }      
        public static Group GetGroupIdByName(string name)
        {
            if(name != default)
            {
                Group tmp = _rockfestDB.OptionsGroup.First(option => option.GroupName == name);
                if (tmp != null)
                {
                    return tmp;
                }
            }
            return new Group();
        }

        public static IQueryable<Group> AllGroups
        {
            get
            {
                return _rockfestDB.OptionsGroup.OrderBy(x => x.Id);
            }
        }

        public static bool AddNewGroupToDataBase(Group group)
        {
            _rockfestDB.OptionsGroup.Add(group);
            if (_rockfestDB.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }


        public static bool RemoveGroup(int id)
        {
            _rockfestDB.OptionsGroup.Remove(_rockfestDB.OptionsGroup.First(grp=> grp.Id==id));
            if (_rockfestDB.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public static bool UpdateData(Group group)
        {
            Group grp = _rockfestDB.OptionsGroup.First(grp => grp.Id == group.Id);
            if (grp != null)
            {
                grp.GroupName = group.GroupName;
                if (_rockfestDB.SaveChanges() == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
