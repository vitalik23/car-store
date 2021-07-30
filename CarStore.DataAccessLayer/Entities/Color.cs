

using CarStore.DataAccessLayer.Entities.Base;

namespace CarStore.DataAccessLayer.Entities
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
