

using CarStore.DataAccessLayer.Entities.Base;
using System;

namespace CarStore.DataAccessLayer.Entities
{
    public class Transport : BaseEntity
    {
        public string Name { get; set; }
        
        public Guid KindTransportId { get; set; }
        public Guid UserId { get; set; }
        
        public virtual KindTransport KindTransport { get; set; }
        public virtual User User { get; set; }
    }
}
