namespace ApiDAy1.models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
      public  List<Product>? products { get; set; }
    }
}
