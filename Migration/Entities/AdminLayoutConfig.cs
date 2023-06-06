using System.Reflection;

namespace Migration.Entities
{
    public class AdminLayoutConfig
    {
        public int Id { get; set; }
        public string Config { get; set; }

        public long newConfig { get; set; }
        public long MyProperty { get; set; }
    }
}
