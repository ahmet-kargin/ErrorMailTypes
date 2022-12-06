using ErrorMailTypes.Models;

namespace ErrorMailTypes.Services
{
    public interface ITemplateService
    {
        MailDto Save(MailDto model);
        MailDto GetByType(string type);
        MailDto Update(MailDto model);
    }
}
