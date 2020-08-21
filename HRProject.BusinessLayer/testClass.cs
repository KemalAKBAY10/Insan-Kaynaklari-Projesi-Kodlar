using HRProject.DataAccessLayer.EntityFrameWork;
using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.BusinessLayer
{
    public class testClass
    {
        private Repository<Members> repoMember = new Repository<Members>();
        public testClass()
        {
             Members mr = repoMember.Find(x => x.MemberName == "test");
        }
    }
}
