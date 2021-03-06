﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Automile.Net
{
    public class ContactEditModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public string CultureName { get; set; }
        //public string CountryCodeIso1366 { get; set; }
        public int? DefaultVehicleId { get; set; }
      //  public ApiUnitType UnitType { get; set; }
    //    public bool SubscribeToNewsLetter { get; set; }
    }
}
