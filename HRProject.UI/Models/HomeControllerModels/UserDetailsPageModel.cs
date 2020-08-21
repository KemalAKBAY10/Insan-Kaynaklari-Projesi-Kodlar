using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRProject.UI.Models.HomeControllerModels
{
    public class UserDetailsPageModel
    {
        public string UserFirstNameAndLastName { get; set; }
        public HRUsersDetails SelectedUser { get; set; }
    }
}