using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Domain.Entities
{
    public class OrganMeatValue : EntityBase
    {

         public OrganMeatValue()
        {

            //OrganMeatType = new List<OrganMeatType>();
        }

        public virtual CutSheetDetail CutSheetDetail { get; set; }

        public virtual OrganMeatType OrganMeatType { get; set; }


        public OmsOrganMeatType OrganMeatTypeId { get; set; }

        public int CutSheetDetailId { get; set; }


       
       
    }
}
