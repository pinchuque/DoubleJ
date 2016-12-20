using System;
using System.Collections.Generic;


namespace DoubleJ.Oms.Domain.Entities
{
    public class BoxSize : EntityBase
    {
        public string Name { get; set; }
        public decimal TareWeight { get; set; }

        public virtual ICollection<Product> Products{ get; set; }

        public bool IsActive { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}