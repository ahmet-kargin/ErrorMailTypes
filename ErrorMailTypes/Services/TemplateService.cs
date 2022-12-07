using ErrorMailTypes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ErrorMailTypes.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly MailTypesContext _context;
        public TemplateService( MailTypesContext context)
        {
            _context = context;
        }
        public MailDto Save(MailDto model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }
        public string GetByType(string type)
        {
            Template selectedTemplate = _context.MailTypes.FirstOrDefault(t => t.MailType == type);

            return selectedTemplate.MailBody;
        }
        public MailDto Update(MailDto model)
        {
            var data = _context.MailTypes.Where(x => x.MailType == model.MailType).SingleOrDefault();
            _context?.Entry(data).CurrentValues.SetValues(model);
            _context?.SaveChanges();
            return model;
        }

    }
}
