namespace Application.Models
{
    public class TaskUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int EstimatePoints { get; set; }          
        public bool Deleted { get; set; }       
    }
}
