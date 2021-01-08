using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class ClassDAO
    {
        UniversityDbContext db = null;
        public ClassDAO()
        {
            db = new UniversityDbContext();
        }
        public IEnumerable<Class> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Class> model = db.Classes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
    }
}
