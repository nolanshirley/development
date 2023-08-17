namespace Interview.Web.Models
{
    public class ProductCategory
    {
        public int InstanceId { get; set; }
        public int CategoryInstanceId { get; set; }
        public virtual Product ProductInstance { get; set; }
        public virtual Category CategoryInstance { get; set; }
    }
}
