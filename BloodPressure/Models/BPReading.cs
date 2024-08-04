namespace BloodPressure.Models
{
    public class BPReading
    {

        public int Id { get; set; }
        public DateOnly DateTaken { get; set; }
        public TimeOnly TimeTaken { get; set; }

        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public int HeartRate { get; set; }


    }
}
