namespace Domain.Entities
{
    public class TaskEntity : BaseEntity
    {       
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int EstimatePoints { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool Deleted { get; set; }
    }
}
