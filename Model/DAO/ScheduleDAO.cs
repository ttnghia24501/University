using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class ScheduleDAO
    {
        UniversityDbContext db = null;

        public ScheduleDAO()
        {
            db = new UniversityDbContext();
        }
        public IEnumerable<Schedule> ListAllPaging( int page, int pageSize)
        {
            return db.Schedules.OrderByDescending(x => x.Date).ToPagedList(page, pageSize);
        }
    }
}
