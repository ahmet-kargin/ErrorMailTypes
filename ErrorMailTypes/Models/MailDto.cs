using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErrorMailTypes.Models
{
    public class MailDto
    {
        
        public int id { get; set; }
       // public string? MailTypeId { get; set; }
        public string? MailType { get; set; }
        public string? MailBody { get; set; }
        //public List<SelectListItem> MailTypeSelectList { get; set; }
    }
}
