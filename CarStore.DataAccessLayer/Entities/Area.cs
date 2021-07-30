using CarStore.DataAccessLayer.Entities.Base;
using System.Collections.Generic;

namespace CarStore.DataAccessLayer.Entities
{
    public class Area : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<City> Cities { get; set; }
        public Area()
        {
            Cities = new List<City>();
        }
    }
}
