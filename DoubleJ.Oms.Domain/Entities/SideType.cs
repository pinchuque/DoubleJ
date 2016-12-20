using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Domain.Entities
{
   public class SideType : IEntity
    {
        public SideType()
        {
            OrderDetail = new List<OrderDetail>();
        }

        public OmsSideType Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

        public int GetId()
        {
            return (int)Id;
        }
    }
}
