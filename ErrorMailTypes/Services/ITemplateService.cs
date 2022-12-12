using EmailTemplate.Models;

namespace EmailTemplate.Services
{
    public interface ITemplateService
    {
        string GetByType(string type);
        TemplateDto Update(TemplateDto model);
    }
}
