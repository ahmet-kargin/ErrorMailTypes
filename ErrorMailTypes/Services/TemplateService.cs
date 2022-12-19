using EmailTemplate.Models;

namespace EmailTemplate.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly TemplateContext _context;
        public TemplateService( TemplateContext context)
        {
            _context = context;
        }
        public  string GetByType(int? type)
        {
            if (type != null)
            {
                Template? selectedTemplate = _context.Templates.FirstOrDefault(t => t.MailTypeId == type);
                return selectedTemplate.MailBody;
            }
            else 
                return "";
        }
        public Template Update(Template model)
        {
            if (model.MailBody == null)
            {
                Template? selectedTemplate = _context.Templates.FirstOrDefault(x => x.MailTypeId == model.MailTypeId);
                selectedTemplate.MailBody = "<h3></h3>"; 
                _context?.SaveChanges();
            }
            else
            {
                Template? selectedTemplate = _context.Templates.FirstOrDefault(x => x.MailTypeId == model.MailTypeId);
                selectedTemplate?.MailBody = model.MailBody;
                _context?.SaveChanges();
            }
            return model;
        }
    }
}
