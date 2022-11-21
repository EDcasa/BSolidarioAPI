using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BSolidarioAPI.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string document_number { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required] 
        public string last_name { get; set; }

        [Required]
        //[ForeignKey("ClientId")]
        public ICollection<ClientPlanType> ClientsPlanType { get; set; }
    }
}
