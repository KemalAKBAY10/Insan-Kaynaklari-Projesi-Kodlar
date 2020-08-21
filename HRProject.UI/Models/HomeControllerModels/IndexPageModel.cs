using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRProject.UI.Models.HomeControllerModels
{
    public class IndexPageModel
    {
        public List<HRUsers> UserList { get; set; }
    }
}