using CarStore.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarStore.DataAccessLayer.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Model> Models { get; set; }

        public Brand()
        {
            Models = new List<Model>();
        }
    }
}
