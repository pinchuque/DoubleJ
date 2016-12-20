using System;

namespace DoubleJ.Oms.Web.Reports.Model
{
    public class ProductItem
    {
        private decimal _weightKg;
        private decimal _weightLbs;
        public string Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal WeightKg
        {
            get { return _weightKg; }
            set { _weightKg = Math.Round(value, 2); }
        }

        public decimal WeightLbs
        {
            get { return _weightLbs; }
            set { _weightLbs = Math.Round(value, 2); }
        }
    }
}