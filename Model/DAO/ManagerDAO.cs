using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Configuration;


namespace Model.DAO
{
    public class ManagerDAO
    {
        UniversityDbContext db = null;
        public ManagerDAO()
        {
            db = new UniversityDbContext();
        }
        public long Insert(Manager entity)
        {
            db.Managers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Manager> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<Manager> model = db.Managers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Email.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page,pageSize);
        }
        public Manager GetById(string email)
        {
            return db.Managers.SingleOrDefault(x => x.Email == email);
        }
        public int Login(string email, string passWord)
        {
            var result = db.Managers.SingleOrDefault(x => x.Email == email);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
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
