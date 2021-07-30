using CarStore.DataAccessLayer.Entities.Base;
using System.Collections.Generic;

namespace CarStore.DataAccessLayer.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public List<Model> Models { get; set; }

        public Brand()
        {
            Models = new List<Model>();
        }
    }
}
