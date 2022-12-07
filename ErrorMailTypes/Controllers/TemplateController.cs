using ErrorMailTypes.Models;
using ErrorMailTypes.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErrorMailTypes.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplateService _templateService;
        private readonly MailTypesContext _mailTypesContext;
        public TemplateController(ITemplateService templateService, MailTypesContext mailTypesContext)
        {
            _templateService = templateService;
            _mailTypesContext = mailTypesContext;
        }
        public IActionResult Index()
        {
            ViewBag.Template = _mailTypesContext.MailTypes.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Save(MailDto model)
        {
            try
            {
                var result = _templateService.GetByType(model.MailType);
                if (result != null)
                {
                    if (result != null)
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
                if (model != null)
                {
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
