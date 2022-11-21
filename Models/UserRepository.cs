using mvc.DB;
using mvc.Entities;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Models
{
    public class UserRepository
    {
        private readonly RockfestDB _rockfestDB;

        public UserRepository(RockfestDB rockfestDB)
        {
            _rockfestDB = rockfestDB;
        }

        //надо ток есль делать админку
        public IQueryable<UserData> allUsers
        {
            get
            {
                return _rockfestDB.UserData.OrderBy(x => x.Id);
            }
        }
        public UserData GetUserWithLogin(string login)
        {
            return _rockfestDB.UserData.First(blogElem => blogElem.Login == login);
        }        
        public bool CheckIsUserRegisterd(string login)
        {
            if (_rockfestDB.UserData.Where(userData => userData.Login == login).Count() == 0)
            {
                return false;
            }
            return true;
        }

        public bool AddNewUserToDataBase(UserData userData)
        {
            _rockfestDB.UserData.Add(userData);
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
