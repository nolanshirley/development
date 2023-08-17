namespace Interview.Web.Models
{
    public class CategoriesCategory
    {
        public int InstanceId { get; set; }
        public int CategoryInstanceId { get; set; }

        public Category Instance { get; set; }
        public virtual Category CategoryInstance { get; set; }
    }
}
