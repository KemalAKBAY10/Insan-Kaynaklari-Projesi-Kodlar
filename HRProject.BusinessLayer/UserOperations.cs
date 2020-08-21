using HRProject.DataAccessLayer.EntityFrameWork;
using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.BusinessLayer
{
    public class UserOperations
    {
        private Repository<HRUsers> repoUser = new Repository<HRUsers>();
        private Repository<HRUsersDetails> repoUserDetails = new Repository<HRUsersDetails>();

        public List<HRUsers> GetAllUsers()
        {
            return repoUser.List();
        }

        public HRUsers GetUser(string UserId)
        {
            return repoUser.Find(x => x.USERID == UserId);
        }

        public HRUsersDetails GetUserDetail(string UserId)
        {
            HRUsersDetails detail = repoUserDetails.Find(x => x.USERID == UserId);
            if (detail != null)
            {
                return detail;
            }
            else
            {
                HRUsersDetails dtl = new HRUsersDetails() { USERID = UserId };
                repoUserDetails.Insert(dtl);
                return dtl;
            }
        }

        public string UserFirsAndLastName(string UserId)
        {
            HRUsers user = repoUser.Find(x => x.USERID == UserId);
            return user.FIRSTNAME + " " + user.LASTNAME;
        }

        public int UpdateUser(HRUsers data)
        {
            HRUsers user = repoUser.Find(x => x.USERID == data.USERID);

            if (user != null)
            {
                user.FIRSTNAME = data.FIRSTNAME;
                user.LASTNAME = data.LASTNAME;
                user.MANAGERUSERID = data.MANAGERUSERID;
                user.COSTCENTER = data.COSTCENTER;
                user.COMPANY = data.COMPANY;
                user.STATUS = data.STATUS;
                user.DEPARTMENTID = data.DEPARTMENTID;
                user.PROFESSIONID = data.PROFESSIONID;
                user.POSITIONID = data.POSITIONID;

                return repoUser.Update(user);
            }
            else
            {
                return 0;
            }
        }

        public int UpdateUserDetail(HRUsersDetails data)
        {
            HRUsersDetails userDetails = repoUserDetails.Find(x => x.USERID == data.USERID);
            if (userDetails != null)
            {
                userDetails.SUBCOMPANY = data.SUBCOMPANY;
                userDetails.COLLAR = data.COLLAR;
                userDetails.SEX = data.SEX;
                userDetails.MARITALSTATUS = data.MARITALSTATUS;
                userDetails.CHILD = data.CHILD;
                userDetails.LOCATION = data.LOCATION;
                userDetails.PAYROLL = data.PAYROLL;
                userDetails.DATEOFWORK = data.DATEOFWORK;
                userDetails.DATEOFBIRTH = data.DATEOFBIRTH;
                userDetails.PLACEOFBIRTH = data.PLACEOFBIRTH;
                userDetails.ADUSERNAME = data.ADUSERNAME;
                userDetails.PASSWORD = data.PASSWORD;
                userDetails.EMAIL = data.EMAIL;
                userDetails.ADDRESS = data.ADDRESS;
                userDetails.BANKSWITCH = data.BANKSWITCH;
                userDetails.BANKACCOUNT = data.BANKACCOUNT;
                userDetails.IBAN = data.IBAN;
                userDetails.TCNO = data.TCNO;
                userDetails.BLOODGROUP = data.BLOODGROUP;
                userDetails.PHONENUMBER = data.PHONENUMBER;
                userDetails.LANGUAGE = data.LANGUAGE;

                return repoUserDetails.Update(userDetails);
            }
            else
            {

            }
            return 0;
        }

        public int InsertUser(HRUsers user, HRUsersDetails UserDetail)
        {

            if (repoUser.Find(x => x.USERID == user.USERID) != null && repoUserDetails.Find(x => x.USERID == UserDetail.USERID) != null)
            {
                return 0;
            }
            else
            {
                int resUser = repoUser.Insert(user);
                int resUsDetail = repoUserDetails.Insert(UserDetail);

                if (resUser == 1 && resUsDetail == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int DeleteUser(string UserId)
        {
            HRUsers user = repoUser.Find(x => x.USERID == UserId);
            if (user != null)
            {
                HRUsersDetails userDetail = repoUserDetails.Find(x => x.USERID == UserId);
                if (userDetail != null)
                {
                    repoUserDetails.Delete(userDetail);
                }

                return repoUser.Delete(user);
            }
            else
            {
                return 0;
            }
            
        }
    }
}
