namespace Interview.Web.Models
{
    public class CategoryAttribute
    {
        // anytime key, value is present in db script this signals to me provider architecture
        // I would rename key and value to ProviderKey and ProviderValue
        public int InstanceId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public virtual Category CategoryInstance { get; set; }

    }
}
