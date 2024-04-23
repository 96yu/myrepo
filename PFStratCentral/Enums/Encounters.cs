namespace PFStratCentral.Enums
{
    public class Encounter
    {
        public EncounterId Id { get; set; }
        public string Name { get; set; }
        public Encounter(EncounterId id, string name)
        {
            Id = id;
            Name = name;
        }

    }
    public enum EncounterId
    {
        P1S = 1,
        P2S = 2,
        P3S = 3,
        P4S = 4,
        P5S = 5,
        P6S = 6,
        P7S = 7,
        P8S = 8,
        P9S = 9,
        P10S = 10,
        P11S = 11,
        P12S = 12
    }
}
