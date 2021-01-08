using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class DepartmentDAO
    {
        UniversityDbContext db = null;
        public DepartmentDAO()
        {
            db = new UniversityDbContext();
        }
        public IEnumerable<Department> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Department> model = db.Departments;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
    }
}
