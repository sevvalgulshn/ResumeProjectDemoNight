namespace ResumeProjectDemoNight.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Title { get; set; } = string.Empty;

        public int Value { get; set; }        
        public bool Status { get; set; }     
    }
}
