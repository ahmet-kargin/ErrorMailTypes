using ErrorMailTypes.Models;

namespace ErrorMailTypes.Services
{
    public interface IEmailService
    {
        MailDto Save(MailDto model);
        MailDto Get();
    }
}
