using Movies.DAL.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.DAL.Entities
{
    [Table("Sales", Schema ="dbo")]
    public class Sales : BaseEntity
    {
        public int ClientId { get; set; }
        public int MovieId { get; set; }
        public double SalePrice { get; set; }
        public DateOnly SaleDate { get; set; }
    }
}
