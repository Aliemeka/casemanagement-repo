using System;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeDomain.Interfaces;
using static System.Web.HttpContext;

namespace ministryofjusticeDomain.Repositories
{
    public class ProfileRepo : IProfileRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationRoleManager _roleManager;

        public ProfileRepo(ApplicationDbContext context)
        {
            _context = context;
            _userManager = Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            _roleManager = Current.GetOwinContext().Get<ApplicationRoleManager>();
        }

        /// <summary>
        /// Updates user profile role tables based on their roles
        /// </summary>
        /// <param name="user"></param>
        /// <param name="lawyer"></param>
        /// <param name="ag"></param>
        /// <param name="hod"></param>
        public void UpdateProfile(ApplicationUser nUser,
            Lawyer lawyer = null,
            AttorneyGeneral ag = null,
            DepartmentHead hod=null)
        {
            var user = _userManager.FindByEmail(nUser.Email);
            user.FirstName = nUser.FirstName;
            user.LastName = nUser.LastName;
            user.EmailConfirmed = true;
            _userManager.Update(user);
            
            if (lawyer!=null)
            {
                lawyer.TimeRegister = DateTime.Now;
                lawyer.ApplicationUserId = user.Id;
                _context.Lawyers.Add(lawyer);
                _context.SaveChanges();
            }

            if (ag != null)
            {
                ag.ApplicationUserId = user.Id;
                _context.AttorneyGenerals.Add(ag);
                _context.SaveChanges();
            }

            if (hod != null)
            {
                hod.ApplicationUserId = user.Id;
                _context.DepartmentHeads.Add(hod);
                _context.SaveChanges();
            }
        }
    }
}
