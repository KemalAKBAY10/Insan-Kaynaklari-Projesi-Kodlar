using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HRProject.Entities;

namespace HRProject.DataAccessLayer.EntityFrameWork
{
    public class HRDB_Initializer : CreateDatabaseIfNotExists<HRProjectContext>
    {
        protected override void Seed(HRProjectContext context)
        {
            Members admin = new Members()
            {
                Name = "Kemal",
                Surname = "AKBAY",
                MemberName = "Admin",
                Email = "test@mail.com",
                Password = "asd"
            };

            context.Members.Add(admin);

            for (int i = 0; i < 3; i++)
            {
                HRUsers user = new HRUsers()
                {
                    USERID = "TU-0" + i,
                    FIRSTNAME = "Test Name" + i,
                    LASTNAME = "test lastname" + i,
                    MANAGERUSERID = "test Manager ID " + i,
                    COSTCENTER = "COSTCENTER " + i,
                    COMPANY = "COMPANY " + i,
                    STATUS = "STATUS" + i,
                    DEPARTMENTID = "TESTDPRT" + i,
                    PROFESSIONID = "TESTPROF" + i,
                    POSITIONID = "TESTPOS" + i
                };
                context.HRUsers.Add(user);

                HRDepartments department = new HRDepartments()
                {
                    DEPARTMENTID = "TESTDPRT" + i,
                    DEPARTMENTNAME = "Test Department" + i,
                    MANAGERID = "Test manager"
                };
                context.HRDepartments.Add(department);

                HRProfessions profession = new HRProfessions()
                {
                    PROFESSIONID = "TESTPROF" + i,
                    PROFESSIONNAME = "Test profession" + i
                };
                context.HRProfessions.Add(profession);

                HRPositions position = new HRPositions()
                {
                    POSITIONID = "TESTPOS" + i,
                    POSITIONNAME = "Test Position" + i
                };
            }

            context.SaveChanges();
        }
    }
}
