using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models.VehicleBrakeModel
{
    public class VehicleBrakeCreate
    {
        [Required]
        public string BrakePart { get; set; }
        
        [Required]
        public string ServicedBy { get; set; }
        
        [Required]
        public int MilageServiced { get; set; }

        [Required]
        public DateTime DateOFService { get; set; }

    }
}
