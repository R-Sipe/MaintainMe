using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Data
{
    public class GeneralMaintenance
    {
        [Key]
        public int VehicleId { get; set; }
        public string ServicedBy { get; set; }
        public DateTime DateOfService { get; set; }
        public int MilageServiced { get; set; }
        public string Description { get; set; }
    }
}
