using HRProject.DataAccessLayer.EntityFrameWork;
using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.BusinessLayer
{
    public class DepartmentOperation
    {
        private Repository<HRDepartments> repoDepartment = new Repository<HRDepartments>();
        public List<HRDepartments> GetAllDepartments()
        {
            return repoDepartment.List();
        }

        public HRDepartments GetDepartment(string departmentId)
        {
            return repoDepartment.Find(x => x.DEPARTMENTID == departmentId);
        }

        public int UpdateDepartment(HRDepartments data)
        {
            HRDepartments department=repoDepartment.Find(x => x.DEPARTMENTID == data.DEPARTMENTID);
            if (department != null)
            {
                department.DEPARTMENTNAME = data.DEPARTMENTNAME;
                department.MANAGERID = data.MANAGERID;
                return repoDepartment.Update(department);
            }
            else
            {
                return 0;
            }
        }

        public int DeleteDepartment(string departmentId)
        {
            HRDepartments department= repoDepartment.Find(x => x.DEPARTMENTID == departmentId);
            if (department != null)
            {
                return repoDepartment.Delete(department);
            }
            else
            {
                return 0;
            }
        }

        public int InsertDepartment(HRDepartments data)
        {
            if (repoDepartment.Find(x => x.DEPARTMENTID == data.DEPARTMENTID) != null)
            {
                return 0;
            }
            else
            {
                return repoDepartment.Insert(data);
            }
        }
    }
}
