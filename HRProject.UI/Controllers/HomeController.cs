using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRProject.UI.Models.HomeControllerModels;

namespace HRProject.UI.Controllers
{
    public class HomeController : Controller
    {
        BusinessLayer.Account AccountOperations = new BusinessLayer.Account();
        BusinessLayer.UserOperations UserOperations = new BusinessLayer.UserOperations();
        BusinessLayer.DepartmentOperation DepartmentOperations = new BusinessLayer.DepartmentOperation();
        BusinessLayer.ProfessionOperations ProfessionOperations = new BusinessLayer.ProfessionOperations();
        BusinessLayer.PositionOperations PositionOperations = new BusinessLayer.PositionOperations();


        public ActionResult Index()
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");
            IndexPageModel mdl = new IndexPageModel() { UserList = UserOperations.GetAllUsers() };
            return View(mdl);
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["LogonUser"] != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.ViewModels.LoginModel member)
        {
            try
            {

                Members mr = new Members { MemberName = member.MemberName, Password = member.Password };
                Members LoginUser = AccountOperations.AccountControl(mr);
                if (LoginUser != null)
                {
                    Session["LogonUser"] = LoginUser;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new Exception("Girdiğiniz bilgiler eksik veya hatalı. Kullanıcı bulunamadı.");
                }
            }
            catch (Exception ex)
            {

                ViewBag.LoginError = ex.Message;
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["LogonUser"] = null;
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult UserPage(string UserId)
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            UserPageModel mdl;

            try
            {
                mdl = new UserPageModel()
                {
                    SelectedUser = UserOperations.GetUser(UserId),
                    Departments = DepartmentOperations.GetAllDepartments(),
                    Professions = ProfessionOperations.GetAllProfessions(),
                    Positions = PositionOperations.GetAllPositions()
                };

                if (mdl == null)
                {
                    throw new Exception("Bir Hata Oluştu. Bu Id'de bir kullanıcı bulunamadı.");
                }
            }
            catch (Exception ex)
            {

                ViewBag.UserPageError = ex.Message;
                return RedirectToAction("Index", "Home");
            }

            return View(mdl);
        }

        [HttpPost]
        public ActionResult UserPage(UserPageModel model)
        {
            try
            {
                int result = UserOperations.UpdateUser(model.SelectedUser);
                if (result == 1)
                {
                    ViewBag.UpdateUserResult = "Kullanıcı başarıyla güncellendi.";
                }
                else
                {
                    ViewBag.UpdateUserResult = "Kullanıcı bilgileri güncellenirken bir hata oluştu.";
                }

            }
            catch (Exception ex)
            {
                ViewBag.UpdateUserResult = ex.Message;
            }
            return RedirectToAction("UserPage","Home", new { UserId = model.SelectedUser.USERID});
        }

        public ActionResult DeleteUser(string UserId)
        {
            int res = UserOperations.DeleteUser(UserId);
            if (res == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.UpdateUserResult = "There was an error deleting the user.";
                return RedirectToAction("UserPage", "Home", new { UserId = UserId });
            }
        }

        [HttpGet]
        public ActionResult UserDetailsPage(string UserId)
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            UserDetailsPageModel mdl;

            try
            {

                mdl = new UserDetailsPageModel()
                {
                    SelectedUser = UserOperations.GetUserDetail(UserId),
                    UserFirstNameAndLastName = UserOperations.UserFirsAndLastName(UserId)
                };

                if (mdl == null)
                {
                    throw new Exception("Bir Hata Oluştu. Bu Id'de bir kullanıcı bulunamadı.");
                }
            }
            catch (Exception ex)
            {

                ViewBag.UserPageError = ex.Message;
                return RedirectToAction("Index", "Home");
            }

            return View(mdl);

        }

        [HttpPost]
        public ActionResult UserDetailsPage(UserDetailsPageModel model)
        {
            try
            {
                int result = UserOperations.UpdateUserDetail(model.SelectedUser);
                if (result == 1)
                {
                    ViewBag.UpdateUserDetailsResult = "Kullanıcı detay bilgileri başarıyla güncellendi.";
                }
                else
                {
                    ViewBag.UpdateUserDetailsResult = "Kullanıcı detay bilgileri güncellenirken bir hata oluştu.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.UpdateUserDetailsResult = ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            ViewBag.Departments = DepartmentOperations.GetAllDepartments();
            ViewBag.Professions = ProfessionOperations.GetAllProfessions();
            ViewBag.Positions = PositionOperations.GetAllPositions();
            AddUserPageModel model = new AddUserPageModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddUser(AddUserPageModel model)
        {
            model.UserDetail.USERID = model.User.USERID;
            bool isSuccess =UserOperations.InsertUser(model.User, model.UserDetail) == 1;
            if (isSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ReAddUser = "Kullanıcı eklerken bir hata oluştu.";
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult Departments()
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");
            DepartmentsPageModel model = new DepartmentsPageModel() { Departments = DepartmentOperations.GetAllDepartments() };

            return View(model);
        }

        [HttpGet]
        public ActionResult EditDepartment(string DepartmentId)
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            EditDepartmentPageModel model = new EditDepartmentPageModel() { SelectedDepartment = DepartmentOperations.GetDepartment(DepartmentId) };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditDepartment(EditDepartmentPageModel department)
        {
            int res = DepartmentOperations.UpdateDepartment(department.SelectedDepartment);
            if (res == 1)
            {
                ViewBag.EditDepartmentResult = "Department information has been updated successfully.";
            }
            else
            {
                ViewBag.EditDepartmentResult = "There was an error updating the department information.";
            }
            return View(department);
        }

        public ActionResult DeleteDepartment(string DepartmentId)
        {
            int res = DepartmentOperations.DeleteDepartment(DepartmentId);
            if (res == 1)
            {
                return RedirectToAction("Departments", "Home");
            }
            else
            {
                ViewBag.EditDepartmentResult = "There was an error deleting the department.";
                return RedirectToAction("EditDepartment", "Home", new { DepartmentId = DepartmentId });
            }
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(AddDepartmentPageModel model)
        {
            int res = DepartmentOperations.InsertDepartment(model.Department);
            if (res == 1)
            {
                return RedirectToAction("Departments", "Home");
            }
            else
            {
                ViewBag.AddDepartmentResult = "There was an error adding the department.";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Professions()
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            ProfessionsPageModel model = new ProfessionsPageModel() { Professions = ProfessionOperations.GetAllProfessions() };
            return View(model);
        }

        [HttpGet]
        public ActionResult EditProfessions(string ProfessionId)
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            EditProfessionPageModel model = new EditProfessionPageModel() { SelectedProfession = ProfessionOperations.GetProfession(ProfessionId) };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfessions(EditProfessionPageModel Profession)
        {
            int res = ProfessionOperations.UpdateProfession(Profession.SelectedProfession);
            if (res == 1)
            {
                ViewBag.EditProfessionResult = "Profession information has been updated successfully.";
            }
            else
            {
                ViewBag.EditProfessionResult = "There was an error updating the profession information.";
            }
            return View(Profession);
        }

        public ActionResult DeleteProfession(string ProfessionId)
        {
            int res = ProfessionOperations.DeleteProfession(ProfessionId);
            if (res == 1)
            {
                return RedirectToAction("Professions", "Home");
            }
            else
            {
                ViewBag.EditProfessionResult = "There was an error deleting the profession.";
                return RedirectToAction("EditProfession", "Home", new { ProfessionId = ProfessionId });
            }
        }

        [HttpGet]
        public ActionResult AddProfession()
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult AddProfession(AddProfessionPageModel model)
        {
            int res = ProfessionOperations.InsertProfession(model.Profession);
            if (res == 1)
            {
                return RedirectToAction("Professions", "Home");
            }
            else
            {
                ViewBag.AddProfessionResult = "There was an error adding the profession.";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Positions()
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            PositionsPageModel model = new PositionsPageModel() { Positions = PositionOperations.GetAllPositions() };
            return View(model);
        }

        [HttpGet]
        public ActionResult EditPosition(string PositionId)
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            EditPositionPageModel model = new EditPositionPageModel() { SelectedPosition = PositionOperations.GetPosition(PositionId) };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPosition(EditPositionPageModel Position)
        {
            int res = PositionOperations.UpdatePosition(Position.SelectedPosition);
            if (res == 1)
            {
                ViewBag.EditPositionResult = "Position information has been updated successfully.";
            }
            else
            {
                ViewBag.EditPositionResult = "There was an error updating the Position information.";
            }
            return View(Position);
        }

        public ActionResult DeletePosition(string PositionId)
        {
            int res = PositionOperations.DeletePosition(PositionId);
            if (res == 1)
            {
                return RedirectToAction("Positions", "Home");
            }
            else
            {
                ViewBag.EditProfessionResult = "There was an error deleting the position.";
                return RedirectToAction("EditPosition", "Home", new { PositionId = PositionId });
            }
        }

        [HttpGet]
        public ActionResult AddPosition()
        {
            if (Session["LogonUser"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult AddPosition(AddPositionPageModel model)
        {
            int res = PositionOperations.InsertPosition(model.Position);
            if (res == 1)
            {
                return RedirectToAction("Positions", "Home");
            }
            else
            {
                ViewBag.AddPositionResult = "There was an error adding the profession.";
            }
            return View();
        }

    }
}