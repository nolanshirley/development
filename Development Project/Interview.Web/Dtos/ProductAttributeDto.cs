using Interview.Web.Models;

namespace Interview.Web.Dtos
{
    public class ProductAttributeDto
    {
        public int InstanceId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public virtual ProductDto ProductInstance { get; set; }
    }
}
