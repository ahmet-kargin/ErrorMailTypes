using TemplateContent.Models;

namespace TemplateContent.Services
{
    public interface ITemplateService
    {
        MailDto Save(MailDto model);
       string GetByType(string type);
        MailDto Update(MailDto model);
    }
}
