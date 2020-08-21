using HRProject.DataAccessLayer.EntityFrameWork;
using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.BusinessLayer
{
    public class Account
    {
        private Repository<Members> repoMember = new Repository<Members>();
        private Repository<HRUsers> repoUser = new Repository<HRUsers>();

        public Members AccountControl(Members member)
        {
            Members LoginMember = repoMember.Find(x => x.MemberName == member.MemberName && x.Password == member.Password);
            return LoginMember;
        }

  
    }
}
