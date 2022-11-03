using mvc.DB;
using mvc.Entities;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Models
{
    public class OptionsRepository
    {

        private readonly RockfestDB _rockfestDB;

        public OptionsRepository(RockfestDB rockfestDB)
        {
            _rockfestDB = rockfestDB;
        }
        public IQueryable<Options> allOptions
        {
            get
            {
                return _rockfestDB.Options.OrderBy(x => x.Group);
            }
        }
        public IQueryable<Options> GetOptionElemByGroup(string group)
        {
            return _rockfestDB.Options.Where(option => option.Group == group);
        }

        public bool AddNewOptionToDataBase(Options options)
        {
            _rockfestDB.Options.Add(options);
            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public int SaveChanges()
        {
            return _rockfestDB.SaveChanges();
        }
    }
}
