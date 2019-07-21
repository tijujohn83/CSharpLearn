using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IAEADataModel.ExternalEntities
{
    [MetadataType(typeof(Rent))]
    public partial class Rent
    {
        [Required]
        public object BoatID;
        [Required]
        public object CustomerID;

        public string BoatName;
        public string CustomerName;
        public int HourlyRate;
    }
}