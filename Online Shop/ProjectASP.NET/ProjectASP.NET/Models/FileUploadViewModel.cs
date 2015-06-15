using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectASP.NET.Models
{
    public class FileUploadViewModel
    {
        public IEnumerable<HttpPostedFileBase> file { get; set; }
    }
}