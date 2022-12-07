using ErrorMailTypes.Models;
using ErrorMailTypes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ErrorMailTypes.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplateService _templateService;
        public TemplateController(ITemplateService templateService)
        {
            _templateService = templateService;
        }
        public IActionResult Index()
        {
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

                    if (result !=null)
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
            return RedirectToAction(nameof(TemplateController.Index));
        }
        [HttpPost]
        public JsonResult Get(string data) 
        {
            try
            {
                //model = _templateService.Get();
                var model = _templateService.GetByType(data);
                if (model != null ) {
                    return Json(model);
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
