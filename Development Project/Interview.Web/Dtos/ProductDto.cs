using Interview.Web.Models;
using System.Collections.Generic;
using System;

namespace Interview.Web.Dtos
{
    public class ProductDto
    {
        public int InstanceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProductImageUris { get; set; }

        public string ValidSkus { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletionTimeStamp { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

        public List<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }
}
