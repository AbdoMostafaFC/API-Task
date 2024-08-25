using ApiDAy1.models;
using Microsoft.EntityFrameworkCore;

namespace ApiDAy1.Repository
{
    public class categoryRepo : Irepository<Category>
    {
        private readonly context cont;

        public categoryRepo(context cont)
        {
            this.cont = cont;
        }
        public void Add(Category t)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category Getbyid(int id)
        {
            var result = cont.categories.Include(c=>c.products).FirstOrDefault(c=>c.id==id);

            return result;
            
        }

        public void put(int id, Category t)
        {
            throw new NotImplementedException();
        }
    }
}
