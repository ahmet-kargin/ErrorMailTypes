using ErrorMailTypes.Models;

namespace ErrorMailTypes.Services
{
    public interface ITemplateService
    {
        //MailViewModel Get();
        MailDto Save(MailDto model);
        MailDto GetByType(string type);
        MailDto Update(MailDto model);
    }
}
