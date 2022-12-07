using ErrorMailTypes.Models;

namespace ErrorMailTypes.Services
{
    public interface ITemplateService
    {
        string GetByType(string type);
        MailDto Update(MailDto model);
    }
}
