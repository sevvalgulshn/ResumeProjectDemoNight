namespace ResumeProjectDemoNight.Entities
{
    public class Certificate
    {
        public int CertificateId { get; set; }
        public string Title { get; set; }
        public string? Organization { get; set; }
        public string? Description { get; set; }
        public string Date { get; set; }          // "2026 - Devam"
        public bool IsOngoing { get; set; }      
        public bool Status { get; set; }          // aktif/pasif
    }
}
