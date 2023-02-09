using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ARSM___Avtobusi_R.S.Makedonija.Models

{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Име:")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Презиме:")]
        public string Surname { get; set; }
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}