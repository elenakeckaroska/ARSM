using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ARSM___Avtobusi_R.S.Makedonija.Models

{
    public class Route
    {
        public Route()
        {
            Companies = new List<Company>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Релација:")]
        public string Relation { get; set; }
        [Required]
        [Display(Name = "Време и место на поаѓање:")]
        public string TimePlace { get; set; }
        [Required]
        [Display(Name = "Цена:")]
        public int Price { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Company> Companies { get; set; }
        public string Text { get; set; } 
    }
}