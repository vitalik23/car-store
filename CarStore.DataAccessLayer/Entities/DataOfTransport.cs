using CarStore.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static CarStore.Shared.Common.Enums.Enum;

namespace CarStore.DataAccessLayer.Entities
{
    public class DataOfTransport : BaseEntity
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public ReverseType Reverse { get; set; }
        public DateTime DateCreateCar { get; set; }
        public double EngineVolume { get; set; } //обьем двигателя
        public double Mileage { get; set; } 
        public KindPetrolType KindPetrol { get; set; } 
        public TransmissionType Transmission { get; set; } 
        public KindBodyType KindBody { get; set; } 
        public string CountryOfOrigin { get; set; } //think
        public Guid ColorId { get; set; }
        public TypeSteeringWheelType TypeSteeringWheel { get; set; } 
        public StateType State { get; set; } 
        public string Description { get; set; } 
        public Guid AreaId { get; set; }
        public bool ClearedByCustoms { get; set; } //расстаможена
        public Guid BrandId { get; set; } 
        public Guid ModelId { get; set; }

        public virtual List<CarPhoto> CarPhoto { get; set; } 
        public virtual Area Area { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Model Model { get; set; }
        public virtual Color Colors { get; set; }

        public DataOfTransport()
        {
            CarPhoto = new List<CarPhoto>();
        }

    }
}
