

using CarStore.DataAccessLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarStore.DataAccessLayer.Entities
{
    public class Color : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
