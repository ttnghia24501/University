using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class StudentSubjectDAO
    {
        UniversityDbContext db = null;
        public StudentSubjectDAO()
        {
            db = new UniversityDbContext();
        }
        public IEnumerable<StudentSubject> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<StudentSubject> model = db.StudentSubjects;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.StudentEmail.Contains(searchString));
            }
            return model.OrderByDescending(x => x.StudentName).ToPagedList(page, pageSize);
        }
    }
}
