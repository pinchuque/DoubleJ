using System.Collections.Generic;

namespace DoubleJ.Oms.Domain.Entities
{ 
    public class CaseType : EntityBase
    {
        public CaseType()
        {
            CaseSizes = new List<CaseSize>();
        }
        public string Name { get; set; }
        public virtual ICollection<CaseSize> CaseSizes { get; set; }
    }
}