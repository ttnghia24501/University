using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class SubjectDAO
    {
        UniversityDbContext db = null;
        public SubjectDAO()
        {
            db = new UniversityDbContext();
        }
        public IEnumerable<Subject>ListAllPaging(int page,int pageSize)
        {
            return db.Subjects.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
    }
}
