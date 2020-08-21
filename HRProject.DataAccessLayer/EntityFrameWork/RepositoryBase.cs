using HRProject.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.DataAccessLayer.EntityFrameWork
{
    public class RepositoryBase
    {
        protected static HRProjectContext db;
        private static object _lockObj = new object();
        
        public RepositoryBase()
        {
            createContext();
        }

        private static void createContext()
        {
            if (db == null)
            {
                lock (_lockObj)
                {
                    if (db==null)
                    {
                        db = new HRProjectContext();
                    }
                }
            }
        }
    }
}
