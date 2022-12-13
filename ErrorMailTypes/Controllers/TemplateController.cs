using EmailTemplate.Models;
using EmailTemplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailTemplate.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplateService _templateService;
        private readonly TemplateContext _templateContext;
        public TemplateController(ITemplateService templateService, TemplateContext templateContext)
        {
            _templateService = templateService;
            _templateContext = templateContext;
        }
        public IActionResult Index()
        {
            ViewBag.Template = _templateContext.MailTypes.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Save(Template model)
        {
            try
            {
                if (model != null)
                {
                    model = _templateService.Update(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction(nameof(TemplateController.Index));
        }
        [HttpPost]
        public JsonResult Get(int data)
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
