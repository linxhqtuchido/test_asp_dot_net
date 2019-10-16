using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using mvcMembers.Models;
using MySql.Data.MySqlClient;    
using System;    
using System.Collections.Generic; 

namespace mvcMembers.Controllers  
{  
    public class MemberController : Controller  
    {  
        public void SetFlash(string text)
        {
            TempData["FlashMessage.Text"] = text;
        }

        [HttpGet]
        public IActionResult Index()  
        {  
            MemberDBContext context = HttpContext.RequestServices.GetService(typeof(mvcMembers.Models.MemberDBContext)) as MemberDBContext;  
            // string abc = "abc";
            return View(context.GetAllMember());  
        }

        [HttpPost]
        public IActionResult Index(Member model)
        {
            // string message = "";
            // message = " surenname " + model.SureName.ToString() + " email " + model.Email.ToString();
            // return Content(message);
            string email = ""; string surename = "";
            if(model.Email == null && model.SureName == null) {
                return RedirectToAction("Index");
            }
            MemberDBContext context = HttpContext.RequestServices.GetService(typeof(mvcMembers.Models.MemberDBContext)) as MemberDBContext;
            if(model.Email != null) {
                email = model.Email.ToString();
            }
            if(model.SureName != null) {
                surename = model.SureName.ToString();
            }
            return View(context.SearchMember(surename, email));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Member model)
        {
            if (ModelState.IsValid)
            {
                if(model.FirstName == null) {
                    SetFlash("Pls complete the inputs (*)");
                    return RedirectToAction("Create");
                }
                if(model.SureName == null) {
                    SetFlash("Pls complete the inputs (*)");
                    return RedirectToAction("Create");
                }
                if(model.Email == null) {
                    SetFlash("Pls complete the inputs (*)");
                    return RedirectToAction("Create");
                }
                // message = "firstname " + model.FirstName.ToString() + " surenname " + model.SureName.ToString() + " email " + model.Email.ToString() + " created successfully";
                MemberDBContext context = HttpContext.RequestServices.GetService(typeof(mvcMembers.Models.MemberDBContext)) as MemberDBContext;
                context.AddMember(model.FirstName.ToString(), model.SureName.ToString(), model.Email.ToString());
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateMember()
        {
           return new EmptyResult();
        }

    }
}  