namespace ApiDAy1.models
{
    public interface Irepository<T>
    {
        public List<T> GetAll();
        public T Getbyid(int id);
        public void put(int id,T t);
        public void delete(int id);
        public void Add(T t);




    }
}
