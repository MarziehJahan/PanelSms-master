using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Panel.DAL;
using PanelSms.Models;

namespace PanelSms.Controllers
{
    public class HomeController : Controller
    {
        
        PanelSimorghContext ctx;
        PanelSimorghViewModel simorghViewModel;
        public HomeController()
        {
            ctx = new PanelSimorghContext();
            simorghViewModel = new PanelSimorghViewModel()
            {
                AcquaintanceTypes = ctx.Acquaintances.Select(a => new SelectListItem()
                {
                    Text = a.AcquaintanceDesc,
                    Value = a.AcquaintanceId.ToString(),
                    Selected=true
                }),
                Conditions = ctx.Conditions,
                UserPanels = ctx.users.Select(a => new SelectListItem()
                {
                    Text = a.UserPanelDescription,
                    Value = a.UserPanelId.ToString()
                }),
                PhoneNumber=null,
                PostalCode=null,
                BirthNo=null,
                NationalCode=null
            };
        }
        public IActionResult Index()
        {
            return View(simorghViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PanelSimorghViewModel model)
        {
            if (ModelState.IsValid)
            {
                ctx.Panels.Add(new PanelSimorgh()
                {
                    acquaintanceType = ctx.Acquaintances.Find(Convert.ToInt32(model.AcquaintanceId)),
                    Address = model.Address,
                    BirthNo = Convert.ToInt32(model.BirthNo),
                    Name = model.Name,
                    FName = model.FName,
                    Email = model.Email,
                    NationalCode = Convert.ToInt32(model.NationalCode),
                    PhoneCall = Convert.ToInt32(model.PhoneCall),
                    PhoneNumber = Convert.ToInt32(model.PhoneNumber),
                    Con = ctx.Conditions.Find(model.ConditionId),
                    PostalCode = Convert.ToInt32(model.PostalCode),
                    terms = ctx.Terms.Find(1),
                    Username = model.Username,
                    userpanel = ctx.users.Find(Convert.ToInt32(model.UserPanelId))
                });
                ctx.SaveChanges();
                ViewBag.Success = ".ثبت نام با موفقیت انجام شد";
                return View(simorghViewModel);
            }
            else
            {
                return View(simorghViewModel);
            }
        }
    }
}
