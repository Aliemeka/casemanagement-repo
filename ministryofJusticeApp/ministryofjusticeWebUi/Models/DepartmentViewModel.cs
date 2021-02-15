using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ministryofjusticeWebUi.Models
{
    public class DepartmentViewModel
    {
        public byte Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}