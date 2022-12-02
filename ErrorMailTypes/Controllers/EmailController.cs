using ErrorMailTypes.Models;
using ErrorMailTypes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;

namespace ErrorMailTypes.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailservice;
        
        SqlDataReader dr;

        public EmailController(IEmailService emailservice)
        {
            _emailservice = emailservice;
        }
        public IActionResult Add()
        {
            MailDto model = new MailDto();
            try
            {
                model = _emailservice.Get();
            }
            catch (Exception ex)
            {
               throw ex;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(MailDto model)
        {
            try
            {
                model = _emailservice.Save(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(model);
        }
       
    }
}
