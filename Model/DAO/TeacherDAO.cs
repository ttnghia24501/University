using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;


namespace Model.DAO
{
    public class TeacherDAO
    {
        UniversityDbContext db = null;

        public TeacherDAO()
        {
            db = new UniversityDbContext();
        }
        public IEnumerable<Teacher> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<Teacher> model = db.Teachers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
    }
}
