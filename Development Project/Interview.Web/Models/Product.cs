using System;
using System.Collections.Generic;

namespace Interview.Web.Models
{
    public class Product
    {
        // would rename to Id and make it Guid, as well as the other tables...

        // add deletion fields to all tables as well when appropriate

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
