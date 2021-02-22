using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeWebUi.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required] public string DepartmentName { get; set; }
    }
}