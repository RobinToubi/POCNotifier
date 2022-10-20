namespace POCNotifier
{
    public class Incident
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public string? Categorie { get; set; }
        public string? Priorite { get; set; }
        public string? Description { get; set; }
        public int? AffectedPerson { get; set; }
        public int? Product { get; set; }
        public int? WaitingList { get; set; }
    }
}
