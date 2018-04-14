using System;

namespace WebService.FitnessOfBand.POCO
{
    public class Wearable
    {
        public int Id { get; set; }
        public string Identification { get; set; }

        public Wearable Information { get; set; }
    }
}