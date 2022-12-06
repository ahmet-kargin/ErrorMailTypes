using ErrorMailTypes.Models;
using ErrorMailTypes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ErrorMailTypes.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplateService _templateService;
        private readonly MailTypesContext _mailTypesContext;
        public TemplateController(ITemplateService templateService, MailTypesContext mailTypesContext )
        {
            _templateService = templateService;
            _mailTypesContext = mailTypesContext;
        }
        public  IActionResult Index()
         {
            //List<MailDto> mailDto = new List<MailDto>();
            ViewBag.Template =  _mailTypesContext.MailTypes.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult Save(MailDto model)
        {
            try
            {
                var result = _templateService.GetByType(model.MailType);
                if (result !=null)
                {
                    if (result.MailType !=null)
                    {
                        model = _templateService.Update(model);
                    }
                    else
                    {
                        model = _templateService.Save(model);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.MailType = model.MailType;
            return RedirectToAction(nameof(TemplateController.Index));
        }
        [HttpPost]
        public JsonResult Get(string data) 
        {
            try
            {
                var model = _templateService.GetByType(data);
                if (model != null && model.MailBody!=null) {
                    return Json(model.MailBody);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("");
        }
               
    }
}
