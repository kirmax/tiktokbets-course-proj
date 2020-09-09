﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialBets.Domain.Core.Models;
using SocialBets.Domain.Interfaces.Database;
using SocialBets.Infrastructure.DataAccess;
using SocialBets.Models;
using SocialBets.Services.Interfaces;

namespace SocialBets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBattleService _battleService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBattleService battleService)
        {
            /*_unitOfWork = unitOfWork;
            _unitOfWork.UserManager.GetUserAsync(User);*/

        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("NonAuthorizedIndex");
            
            ICollection<CurrentBattle> battles = await _battleService.GetBattles();
            return View("Index", battles);
        }


        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Registration()
        {
            return StatusCode(200);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
