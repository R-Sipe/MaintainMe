using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models.VehicleBrakeModel
{
    public class VehicleBrakeEdit
    {
        public int VehicleId
        {
            get; set;
        }
        public string BrakePart
        {
            get; set;
        }
        public string ServicedBy
        {
            get; set;
        }
        public DateTime DateOFService
        {
            get; set;
        }
        public int MilageServiced
        {
            get; set;
        }
     }
}
