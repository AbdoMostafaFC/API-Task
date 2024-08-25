namespace ApiDAy1.DTO
{
    public class CategoryDetalis
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public  List<string> products { get; set; }=new List<string>();
    }
}
