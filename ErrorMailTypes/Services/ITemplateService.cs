using EmailTemplate.Models;

namespace EmailTemplate.Services
{
    public interface ITemplateService
    {
        string GetByType(int type);
        Template Update(Template model);
    }
}
