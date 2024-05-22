namespace Application.Models
{
    public class TaskCreateViewModel
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int EstimatePoints { get; set; }
        public DateTime CreateDate { get; set; }  
    }
}
