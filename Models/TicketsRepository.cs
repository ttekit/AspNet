using mvc.DB;
using mvc.Entities;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Models
{
    public class TicketsRepository
    {

        private readonly RockfestDB _rockfestDB;

        public TicketsRepository(RockfestDB rockfestDB)
        {
            _rockfestDB = rockfestDB;
        }
        public IQueryable<Options> allOptions
        {
            get
            {
                return _rockfestDB.Options.OrderBy(x => x.GroupId);
            }
        }

        public bool AddNewTicketToDataBase(GuestTicket guestTicket)
        {
            _rockfestDB.GuestTicket.Add(guestTicket);
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
