

using CarStore.DataAccessLayer.Entities.Base;
using System;

namespace CarStore.DataAccessLayer.Entities
{
    public class CarPhoto : BaseEntity
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Guid TransportId { get; set; } 
        public virtual Transport Transport { get; set; }
    }
}
