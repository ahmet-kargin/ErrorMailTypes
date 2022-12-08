using ErrorMailTypes.Models;

namespace ErrorMailTypes.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly MailTypesContext _context;
        public TemplateService( MailTypesContext context)
        {
            _context = context;
        }
        public string GetByType(string type)
        {
            if (type != null)
            {
                Template selectedTemplate = _context.MailTypes.FirstOrDefault(t => t.MailType == type);
                return selectedTemplate.MailBody;

            }
            else 
                return "";
        }
        public MailDto Update(MailDto model)
        {
            if (model.MailType == null)
                return null;

            if (model.MailBody == null)
            {
                Template selectedTemplate = _context.MailTypes.FirstOrDefault(x => x.MailType == model.MailType);
                selectedTemplate.MailBody = "<h3></h3>"; 
                _context?.SaveChanges();
            }
            else
            {
                string templateBody = model.MailBody;
                var data = _context.MailTypes.FirstOrDefault(x => x.MailType == model.MailType);
                data.MailBody = templateBody;
                _context?.SaveChanges();
            }
            return model;
        }
    }
}
