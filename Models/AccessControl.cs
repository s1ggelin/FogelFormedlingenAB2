﻿using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace FogelFormedlingenAB.Data
{
    public class AccessControl
    {
        public int LoggedInAccountID { get; set; }
        public string LoggedInAccountName { get; set; }

        public AccessControl(AppDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext.User;
            string subject = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            string issuer = user.FindFirst(ClaimTypes.NameIdentifier).Issuer;
         
            LoggedInAccountID = db.Accounts.Single(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject).ID;
            LoggedInAccountName = user.FindFirst(ClaimTypes.Name)?.Value;
			if (LoggedInAccountName.IsNullOrEmpty())
			{
				LoggedInAccountName = user.FindFirst("name").Value;
			}
		}
    }
}
