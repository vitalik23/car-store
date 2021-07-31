

using CarStore.DataAccessLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarStore.DataAccessLayer.Entities
{
    public class City : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
