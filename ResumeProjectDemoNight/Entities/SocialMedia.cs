namespace ResumeProjectDemoNight.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Title { get; set; }     // LinkedIn, GitHub
        public string Url { get; set; }
        public string Icon { get; set; }   // fa fa-linkedin İCON
        public bool Status { get; set; }
    }
}
