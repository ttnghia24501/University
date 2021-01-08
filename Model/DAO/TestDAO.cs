using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;


namespace Model.DAO
{
    public class TestDAO
    {
        UniversityDbContext db = null;

        public TestDAO()
        {
            db = new UniversityDbContext();
        }
        public IEnumerable<Test> ListAllPaging(int page, int pageSize)
        {
            return db.Tests.OrderByDescending(x => x.Status).ToPagedList(page, pageSize);
        }
    }
}
