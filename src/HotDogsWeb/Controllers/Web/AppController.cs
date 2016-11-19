using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotDogsWeb.ViewModels;
using HotDogsWeb.Services;
using Microsoft.Extensions.Configuration;
using HotDogsWeb.Context;
using Microsoft.Extensions.Logging;

namespace HotDogsWeb.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IHotDogsRepository _repository;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService, IConfigurationRoot config, IHotDogsRepository context,
            ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var data = _repository.GetAllStores();
                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get stores in Index page : {ex.Message}");
                return Redirect("/Error");
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contact)
        {
            if (contact.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("Email", "lapin !");
            }

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], contact.Email, "From " + contact.Name, contact.Message);

                ModelState.Clear();
                ViewBag.UserMessage = "Message Sent";
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
