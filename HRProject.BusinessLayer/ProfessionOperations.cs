using HRProject.DataAccessLayer.EntityFrameWork;
using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.BusinessLayer
{
    public class ProfessionOperations
    {
        Repository<HRProfessions> repoProfessions = new Repository<HRProfessions>();
        public List<HRProfessions> GetAllProfessions()
        {
            return repoProfessions.List();
        }

        public HRProfessions GetProfession(string professionId)
        {
            return repoProfessions.Find(x => x.PROFESSIONID == professionId);
        }

        public int UpdateProfession(HRProfessions data)
        {
            HRProfessions profession = repoProfessions.Find(x => x.PROFESSIONID == data.PROFESSIONID);
            if (profession != null)
            {
                profession.PROFESSIONNAME = data.PROFESSIONNAME;
                return repoProfessions.Update(profession);
            }
            else
            {
                return 0;
            }
        }

        public int DeleteProfession(string professionId)
        {
            HRProfessions profession = repoProfessions.Find(x => x.PROFESSIONID == professionId);
            if (profession != null)
            {
                return repoProfessions.Delete(profession);
            }
            else
            {
                return 0;
            }
        }

        public int InsertProfession(HRProfessions data)
        {
            if (repoProfessions.Find(x => x.PROFESSIONID == data.PROFESSIONID) != null)
            {
                return 0;
            }
            else
            {
                return repoProfessions.Insert(data);
            }
        }
    }
}
