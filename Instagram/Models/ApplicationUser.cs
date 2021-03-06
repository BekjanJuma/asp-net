﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Instagram.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace Instagram.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public byte[] Avatar { get; set; }
        public string FullName { get; set; }
        public string AboutMe { get; set; }
        public bool Sex { get; set; }

        public int numPosts { get; set; }
        public int numFollowers { get; set; }
        public int numFollowings { get; set; }

      [JsonIgnore]
      [Display(Name = @"Posts", ResourceType = typeof(Strings))]
        public virtual List<Post> Posts { get; set; }
    }
    
}