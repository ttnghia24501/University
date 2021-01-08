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
        public IEnumerable<Subject> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<Subject> model = db.Subjects;
                if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
    }
}
