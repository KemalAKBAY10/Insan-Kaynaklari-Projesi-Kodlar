using HRProject.DataAccessLayer.EntityFrameWork;
using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.BusinessLayer
{
    public class PositionOperations
    {
        Repository<HRPositions> repoPositions = new Repository<HRPositions>();
        public List<HRPositions> GetAllPositions()
        {
            return repoPositions.List();
        }

        public HRPositions GetPosition(string positionId)
        {
            return repoPositions.Find(x => x.POSITIONID == positionId);
        }

        public int UpdatePosition(HRPositions data)
        {
            HRPositions position = repoPositions.Find(x => x.POSITIONID == data.POSITIONID);
            if (position != null)
            {
                position.POSITIONNAME = data.POSITIONNAME;
                return repoPositions.Update(position);
            }
            else
            {
                return 0;
            }
        }

        public int DeletePosition(string positionId)
        {
            HRPositions position = repoPositions.Find(x => x.POSITIONID == positionId);
            if (position != null)
            {
                return repoPositions.Delete(position);
            }
            else
            {
                return 0;
            }
        }

        public int InsertPosition(HRPositions data)
        {
            if (repoPositions.Find(x => x.POSITIONID == data.POSITIONID) != null)
            {
                return 0;
            }
            else
            {
                return repoPositions.Insert(data);
            }
        }
    }
}
