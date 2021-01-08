using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class StudentDAO
    {
        UniversityDbContext db = null;
        public StudentDAO()
        {
            db = new UniversityDbContext();
        }
        public IEnumerable<Student> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Student> model = db.Students;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x=> x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
    }   
}



