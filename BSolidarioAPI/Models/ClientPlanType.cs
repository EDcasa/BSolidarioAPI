using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BSolidarioAPI.Models
{
    public class ClientPlanType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        //[Required]
        //public int ClientId { get; set; }
        //[Required]
        //public int PlanTypeId { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal annual_interested { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal montly_interested { get; set; }

        [Required]
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }

        [Required]
        [ForeignKey("PlanTypeId")]
        public PlanType PlanType { get; set; }
        public int PlanTypeId { get; set; }

    }
}
