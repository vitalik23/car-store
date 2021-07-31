
using CarStore.DataAccessLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarStore.DataAccessLayer.Entities
{
    public class Model : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
