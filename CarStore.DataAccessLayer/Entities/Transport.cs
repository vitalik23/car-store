

using CarStore.DataAccessLayer.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarStore.DataAccessLayer.Entities
{
    public class Transport : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid KindTransportId { get; set; }
        public Guid UserId { get; set; }
        
        public virtual KindTransport KindTransport { get; set; }
        public virtual User User { get; set; }
    }
}
