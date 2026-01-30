namespace ResumeProjectDemoNight.Entities
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string ProjectTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

        //Opsiyonel kategori***
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
