using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRProject.UI.Models.HomeControllerModels
{
    public class UserPageModel
    {
        public HRUsers SelectedUser { get; set; }
        public List<HRDepartments> Departments { get; set; }
        public List<HRProfessions> Professions { get; set; }
        public List<HRPositions> Positions { get; set; }
    }
}