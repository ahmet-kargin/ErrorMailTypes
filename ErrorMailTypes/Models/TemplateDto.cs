using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmailTemplate.Models
{
    public class TemplateDto
    {
        public int Id { get; set; }
        public string? MailType { get; set; }
        public string? MailBody { get; set; }
    }
}
