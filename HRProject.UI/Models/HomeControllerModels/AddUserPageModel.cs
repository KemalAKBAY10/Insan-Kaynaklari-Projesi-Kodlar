using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRProject.UI.Models.HomeControllerModels
{
    public class AddUserPageModel
    {
        public HRUsers User { get; set; }
        public HRUsersDetails UserDetail { get; set; }
    }
}