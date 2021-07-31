using CarStore.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarStore.Shared.Common.Enums.Enum;

namespace CarStore.DataAccessLayer.Entities
{
    public class DataOfTransport : BaseEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Required]
        public ReverseType Reverse { get; set; }
        [Required]
        public DateTime DateCreateCar { get; set; }
        [Required]
        public double EngineVolume { get; set; } //обьем двигателя
        [Required]
        public double Mileage { get; set; }
        [Required]
        public KindPetrolType KindPetrol { get; set; }
        [Required]
        public TransmissionType Transmission { get; set; }
        [Required]
        public KindBodyType KindBody { get; set; } 
        public string CountryOfOrigin { get; set; } //think
        public Guid ColorId { get; set; }
        public TypeSteeringWheelType TypeSteeringWheel { get; set; }
        [Required]
        public StateType State { get; set; } 
        public string Description { get; set; }
        [Required]
        public Guid AreaId { get; set; }
        public bool ClearedByCustoms { get; set; } //расстаможена
        [Required]
        public Guid BrandId { get; set; }
        [Required]
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
