using EmailTemplate.Models;

namespace EmailTemplate.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly TemplateContext _context;
        Template selectedTemplate;
        public TemplateService( TemplateContext context)
        {
            _context = context;
        }
        public  string GetByType(int type)
        {
            if (type != null)
            {
                selectedTemplate =_context.MailTypes.FirstOrDefault(t => t.MailTypeId == type);
                return selectedTemplate.MailBody;
            }
            else 
                return "";
        }
        public Template Update(Template model)
        {
            if (model.MailBody == null)
            {
                selectedTemplate = _context.MailTypes.FirstOrDefault(x => x.MailTypeId == model.MailTypeId);
                selectedTemplate.MailBody = "<h3></h3>"; 
                _context?.SaveChanges();
            }
            else
            {
                string templateBody = model.MailBody;
                var data = _context.MailTypes.FirstOrDefault(x => x.MailTypeId == model.MailTypeId);
                data.MailBody = templateBody;
                _context?.SaveChanges();
            }
            return model;
        }
    }
}
