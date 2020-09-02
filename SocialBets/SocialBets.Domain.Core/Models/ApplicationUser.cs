﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;


namespace SocialBets.Domain.Core.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string ImagePath { get; set; }
        public MoneyAccount MoneyAccount { get; set; }
        public UserInfo UserInfo { get; set; }
        public Statistics Statistics { get; set; }
        public List<CurrentBattle> CurrentBattles { get; set; }
    }
}
