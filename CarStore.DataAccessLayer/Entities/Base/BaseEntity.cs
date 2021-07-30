using System;

namespace CarStore.DataAccessLayer.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
        }
    }
}
