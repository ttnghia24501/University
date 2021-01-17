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
                model = model.Where(x=> x.Name.Contains(searchString) || x.Email.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
        public Student GetById(string email)
        {
            return db.Students.SingleOrDefault(x => x.Email == email);
        }
        public int Login(string email, string passWord)
        {
            var result = db.Students.SingleOrDefault(x => x.Email == email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }
    }   
}



