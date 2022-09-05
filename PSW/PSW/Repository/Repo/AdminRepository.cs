using PSW.Model.MyDbContext;
using PSW.Model.Users;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.Repo
{
    public class AdminRepository : IAdminRepository
    {

        private readonly MyDbContext dbContext;

        public AdminRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Admin FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Admin> entities)
        {
            throw new NotImplementedException();
        }

        public Admin FindByEmailAndPassword(String email, String password)
        {
            return dbContext.Admins.SingleOrDefault((Admin a) => a.Email.Equals(email) && a.Password.Equals(password));
        }

    }
}
