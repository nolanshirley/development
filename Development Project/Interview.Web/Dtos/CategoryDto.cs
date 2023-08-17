using System;

namespace Interview.Web.Dtos
{
    public class CategoryDto
    {
        public int InstanceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTimestamp { get; set; }
    }
}
