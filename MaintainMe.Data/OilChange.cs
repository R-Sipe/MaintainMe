using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Data
{
    public class OilChange
    {
        [Key]
        public int VehicleId { get; set; }
        public string ServicedBy { get; set; }
        public DateTime DateOFService { get; set; }
        public int MilageServiced { get; set; }
        public string OilType { get; set; }
    }
}
