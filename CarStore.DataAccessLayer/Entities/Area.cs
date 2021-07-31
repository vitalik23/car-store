using CarStore.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarStore.DataAccessLayer.Entities
{
    public class Area : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual List<City> Cities { get; set; }
        public Area()
        {
            Cities = new List<City>();
        }
    }
}
