using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Domain.Entities
{
    public class SteakType : IEntity
    {
       
        public SteakType()
        {
            CutSheetDetail = new List<CutSheetDetail>();
        }

        public string Name { get; set; }
        public virtual ICollection<CutSheetDetail> CutSheetDetail { get; set; }

         public OmsSteakType Id { get; set; }
         public int GetId()
        {
            return (int)Id;
        }


    }
}

