using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Domain.Entities
{
    public class OrganMeatType : IEntity
    {
        public OrganMeatType()
        {
            OrganMeatValue = new List<OrganMeatValue>();
        }

        public string Name { get; set; }

        public OmsOrganMeatType Id { get; set; }
        public int GetId()
        {
            return (int)Id;
        }

        public virtual ICollection<OrganMeatValue> OrganMeatValue { get; set; }
    }
}
