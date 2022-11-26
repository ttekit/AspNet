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
                return _rockfestDB.Options.OrderBy(x => x.Id);
            }
        }
        public IQueryable<Options> GetOptionElemByGroupId(int GroupId)
        {
            IQueryable<Options> tmp = _rockfestDB.Options.Where(option => option.GroupId == GroupId);
            if(tmp != default)
            {
                return tmp;
            }
            else
            {
                return default;
            }
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
        public bool UpdateOption(Options options)
        {
            Options opt = _rockfestDB.Options.First(opt => opt.Id == options.Id);
            if (opt != null)
            {
                opt.GroupId = options.GroupId;
                opt.Value = options.Value;
                opt.Href = options.Href;
                opt.Icon = options.Icon;
            }

            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }
        public bool RemoveOption(int id)
        {
            _rockfestDB.Options.Remove(_rockfestDB.Options.First(opt => opt.Id == id));
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
