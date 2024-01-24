namespace HelpDesk.WebUI.Models
{
    public abstract class GeneralModel
    {
        public DateTime? CreatedDate { get; set; }
        //public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        //public string? ModifiedBy { get; set; }
    }
}
