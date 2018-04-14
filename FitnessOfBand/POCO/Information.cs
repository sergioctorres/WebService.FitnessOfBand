using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.FitnessOfBand.POCO
{
    public class Information
    {
        public int Id { get; set; }
        public int Wearable_Id { get; set; }
        public DateTime InitialDateTime { get; set; }
        public DateTime FinishedDateTime { get; set; }
        public int InitialHeartRate { get; set; }
        public int FinalHeartRate { get; set; }
        public long InitialDistance { get; set; }
        public long FinalDistance { get; set; }
        public long InitialSteps { get; set; }
        public long FinalSteps { get; set; }
        public long InitialCalories { get; set; }
        public long FinalCalories { get; set; }
    }
}