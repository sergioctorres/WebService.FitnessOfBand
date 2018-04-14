using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.FitnessOfBand.POCO
{
    public class RealTime
    {
        public int Id { get; set; }
        public int Wearable_Id { get; set; }
        public DateTime CapturedDateTime { get; set; }
        public int HeartRate { get; set; }
        public int Speed { get; set; }
        public int Pace { get; set; }
        public long TotalDistance { get; set; }
        public long TotalSteps { get; set; }
        public long Calories { get; set; }
    }
}