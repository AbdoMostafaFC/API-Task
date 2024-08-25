using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDAy1.models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        [ForeignKey("catergory")]
        public int CAtegoryID { get; set; }
        public Category? catergory { get; set; }

    }
}
