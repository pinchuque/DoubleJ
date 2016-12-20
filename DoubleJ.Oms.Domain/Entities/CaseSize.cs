using System;
using System.Collections.Generic;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Domain.Entities
{
    public class CaseSize : EntityBase
    {
        public CaseSize()
        {
            CreateDateTime = DateTime.Today;
            CustomerTypeId = OmsCustomerType.Fabrication;
        }
        public string Name { get; set; }
        public int CaseTypeId { get; set; }
        public decimal TareWeight { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateDateTime { get; set; }

        public virtual CaseType CaseType { get; set; }
        public OmsCustomerType? CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }

        public virtual ICollection<Product> ProductsBoxes { get; set; }
        public virtual ICollection<Product> ProductsBags { get; set; }
        public ICollection<CustomerProductData> CustomerProductDataBags { get; set; }
        public ICollection<CustomerProductData> CustomerProductDataBoxes { get; set; }
    }
}