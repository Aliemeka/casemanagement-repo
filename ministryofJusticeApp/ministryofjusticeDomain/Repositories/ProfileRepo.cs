using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeDomain.Interfaces;

namespace ministryofjusticeDomain.Repositories
{
    public class ProfileRepo : IProfileRepo
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Updates user profile role tables based on their roles
        /// </summary>
        /// <param name="user"></param>
        /// <param name="lawyer"></param>
        /// <param name="ag"></param>
        /// <param name="hod"></param>
        public void UpdateProfile(ApplicationUser user, 
            Lawyer lawyer = null, 
            AttorneyGeneral ag=null, 
            DepartmentHead hod = null)
        {
            if (lawyer != null)
            {
                lawyer.TimeRegister = DateTime.Now;
                _context.Lawyers.Add(lawyer);
                _context.SaveChanges();
            }

            if (ag != null)
            {
                _context.AttorneyGenerals.Add(ag);
                _context.SaveChanges();
            }

            if (hod != null)
            {
                _context.DepartmentHeads.Add(hod);
                _context.SaveChanges();
            }
        }
    }
}
