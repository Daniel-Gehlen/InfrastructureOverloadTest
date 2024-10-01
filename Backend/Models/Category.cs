namespace Backend.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int TotalComputers { get; set; }
        public int ComputersInOfficeC { get; set; }
        public int Offices { get; set; }
        public int AccessPointsPerOffice { get; set; }
        public int ScenarioI { get; set; }
        public int ScenarioII { get; set; }
        public double ProbabilityC { get; set; }
    }
}
