using ApiDAy1.models;

namespace ApiDAy1.Repository
{
    public class productRepository:Irepository<Product>
    {
        private readonly context context;

        public productRepository(context context)
        {
            this.context = context;
        }

        public void Add(Product t)
        {
           context.Add(t);
            context.SaveChanges();
           
        }

        public void delete(int id)
        {
            var xx=context.Products.FirstOrDefault(p=>p.id==id);
            context.Remove(xx);
            context.SaveChanges();
        }

        public List<Product> GetAll()
        {
           return context.Products.ToList();
        }

        public Product Getbyid(int id)
        {
            return context.Products.FirstOrDefault(p => p.id == id);
        }

        public void put(int id, Product t)
        {
           Product p=context.Products.FirstOrDefault(p=>p.id==id);
            p.name=t.name;
            p.price=t.price;
            p.quantity=t.quantity;
            p.description=t.description;
            context.SaveChanges();
        }
    }
}
