using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ARSM___Avtobusi_R.S.Makedonija.Models
{
    public class Company
    {
        [Required]
        [Display(Name = "Име на компанијата:")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Опис:")]
        public string Description { get; set; }
        [Required]
        public string Logo { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Сопственик:")]
        public string OwnerName { get; set; }
        [Display(Name = "Релации кои ги нудиме:")]
        public virtual ICollection<Route> Routes { get; set; }

        
    }
}